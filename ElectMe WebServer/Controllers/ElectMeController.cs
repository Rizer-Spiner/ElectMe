using System.Collections.Generic;
using System.Numerics;
using System.Text;
using ElectMe_WebServer.ECIES;
using ElectMe_WebServer.ECIES.util;
using ElectMe_WebServer.KeyGeneration;
using ElectMe_WebServer.LoginServerMock;
using ElectMe_WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ElectMe_WebServer.Controllers
{
    [ApiController]
    [Route("[electMe]")]
    public class ElectMeController
    {
        private readonly ILogger<ElectMeController> _logger;
        private readonly ElectMeLoginServer _login;
        private Dictionary<string, EllipticCurvePoint> _subscribers;
      

        public ElectMeController(ILogger<ElectMeController> logger, ElectMeLoginServer login)
        {
            _logger = logger;
            _login = login;
            _subscribers = new Dictionary<string, EllipticCurvePoint>();
        }


        [HttpGet]
        [Consumes("application/json")]
        public CA getStartEncryptionVariable()
        {
            return EncryptionVariables.certificate;
        }


        [HttpGet]
        [Route("/login")]
        public string login([FromBody] string message)
        {
            if (verifySignature(Encoding.ASCII.GetBytes(message),
                Encoding.ASCII.GetBytes(EncryptionVariables.PrkcForClient.ToString())))
            {
                message = getEncryptedContent(message);
                LoginForm loginForm = JsonConvert.DeserializeObject<LoginForm>(message);

                if (loginForm != null)
                {
                    EllipticCurvePoint sharedKey = KeyGeneration.KeyGeneration.calculatePublicKey(
                        EncryptionVariables.PrkcForClient, loginForm.ClientPuk,
                        EncryptionVariables.EllipticCurveForClient);
                    byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());

                    AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
                    byte[] Kenc = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
                    byte[] Kmac = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);

                    NIOSLoginResult NIOSLogin = _login.login(loginForm.EncryptedCredentials);
                    LoginResult result;
                    if (NIOSLogin.Status.Equals(200))
                    {
                        string deviceToken = getNewDeviceToken();
                        registerDevice(deviceToken, loginForm.ClientPuk);
                        result = new()
                        {
                            DeviceToken = deviceToken,
                            VoteToken = NIOSLogin.Token,
                            Status = 200,
                            Choices = getElectionChoices()
                        };
                    }
                    else
                    {
                        result = new()
                        {
                            Status = 401
                        };
                    }

                    string resultJson = JsonConvert.SerializeObject(result);

                    byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
                    byte[] signedData = MAC.GetTag(encryptedData, Kmac);

                    return Encoding.ASCII.GetString(signedData);
                }
            }

            return "";
        }

      

        [HttpGet]
        [Route("/logout/{deviceToken}")]
        public string logout([FromBody] string message, string deviceToken)
        {
            EllipticCurvePoint clientPuk = getPuK(deviceToken);

            EllipticCurvePoint sharedKey = KeyGeneration.KeyGeneration.calculatePublicKey(
                EncryptionVariables.PrkcForClient, clientPuk,
                EncryptionVariables.EllipticCurveForClient);
            byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());

            AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
            byte[] Kenc = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
            byte[] Kmac = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);

            if (MAC.VerifyTag(Encoding.ASCII.GetBytes(message), Kmac))
            {
                byte[] encryptedContent = MAC.extractEncryptedContent(Encoding.ASCII.GetBytes(message), Kmac);
                string token = aes.Decrypt(encryptedContent, Kenc);

                NIOSLoginResult NIOSlogout = _login.logout(token);

                LoginResult result = new()
                {
                    DeviceToken = deviceToken,
                    VoteToken = token,
                    Status = NIOSlogout.Status
                };

                string resultJson = JsonConvert.SerializeObject(result);

                byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
                byte[] signedData = MAC.GetTag(encryptedData, Kmac);

                return Encoding.ASCII.GetString(signedData);
            }

            return "";
        }


        [HttpPost]
        [Route("/vote/{deviceId}")]
        public string vote([FromBody] string message, string deviceToken)
        {
            EllipticCurvePoint clientPuk = getPuK(deviceToken);

            EllipticCurvePoint sharedKey = KeyGeneration.KeyGeneration.calculatePublicKey(
                EncryptionVariables.PrkcForClient, clientPuk,
                EncryptionVariables.EllipticCurveForClient);
            byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());

            AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
            byte[] Kenc = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
            byte[] Kmac = new KDF().DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);

            if (MAC.VerifyTag(Encoding.ASCII.GetBytes(message), Kmac))
            {
                byte[] encryptedVote = MAC.extractEncryptedContent(Encoding.ASCII.GetBytes(message), Kmac);
                string voteSerialized = aes.Decrypt(encryptedVote, Kenc);

                Vote vote = JsonConvert.DeserializeObject<Vote>(voteSerialized);
                VoteResult result = placeVote(vote);

                string resultJson = JsonConvert.SerializeObject(result);

                byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
                byte[] signedData = MAC.GetTag(encryptedData, Kmac);

                return Encoding.ASCII.GetString(signedData);
            }

            return "";
        }

        private VoteResult placeVote(Vote vote1)
        {
            return new() {Status = 200};
        }

        private EllipticCurvePoint getPuK(string deviceToken)
        {
            EllipticCurvePoint clientPuk = _subscribers[deviceToken];
            return clientPuk;
        }

        private void registerDevice(string deviceToken, EllipticCurvePoint loginFormClientPuk)
        {
            _subscribers.Add(deviceToken, loginFormClientPuk);
        }

        private string? getNewDeviceToken()
        {
            return PrivateKeyGenerator.generatePrivateKey().ToString();
        }

        private string getEncryptedContent(string message)
        {
            return message;
        }

        private bool verifySignature(byte[] message, byte[] key)
        {
            return true;
        }
        
        private List<string> getElectionChoices()
        {
            List<string> list = new List<string>();
            list.Add("Donald Trump");
            list.Add("Hillary Clinton");
            list.Add("Barrack Obama");

            return list;
        }
    }
}