using System;
using System.Collections.Generic;
using System.Text;
using ElectMe_WebServer.ECIES;
using ElectMe_WebServer.ECIES.Common.ECC;
using ElectMe_WebServer.ECIES.KeyGeneration;
using ElectMe_WebServer.ECIES.util;
using ElectMe_WebServer.LoginServerMock;
using ElectMe_WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ElectMe_WebServer.ECIES.ECDSA;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace ElectMe_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectMeController : ControllerBase
    {
        private readonly ILogger<ElectMeController> _logger;
        private readonly ElectMeLoginServer _login;
        private Dictionary<string, EllipticCurvePoint> _subscribers;


        public ElectMeController(ILogger<ElectMeController> logger)
        {
            _logger = logger;
            _login = new ElectMeLoginServerImpl();
            _subscribers = new Dictionary<string, EllipticCurvePoint>();
        }


        //stuff controller should know

        [HttpGet]
        [Route("/connect")]
        public string GetInitialPackage()
        {
            return getInitialPackage();
        }

        [HttpPost]
        [Route("/login")]
        public string Login([FromBody] string message)
        {
            return loginClientToLoginServer(message);
        }


        //stuff that controller shouldn't know
        // private bool verifyMessage(string message)
        // {
        //     JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        //     serializerOptions.Converters.Add(new BigIntegerConverter());
        //     Signature signature = JsonSerializer.Deserialize<Signature>(message, serializerOptions);
        //
        //     return Verifying.verifyMessage(signature, message, EncryptionVariables.PukForClients,
        //         EncryptionVariables.EllipticCurveForClient);
        // }
        
        // https://weblog.west-wind.com/posts/2017/sep/14/accepting-raw-request-body-content-in-aspnet-core-api-controllers
        // public static async Task<string> GetRawBodyStringAsync(this HttpRequest request, Encoding encoding = null)
        // {
        //     if (encoding == null)
        //         encoding = Encoding.UTF8;
        //
        //     using (StreamReader reader = new StreamReader(request.Body, encoding))
        //         return await reader.ReadToEndAsync();
        // }


        private string loginClientToLoginServer(string message)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new BigIntegerConverter());

            LoginContainer loginContainer = JsonSerializer.Deserialize<LoginContainer>(message, serializerOptions);
            EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(EncryptionVariables.PrkcForClient,
                loginContainer.clientPuk, EncryptionVariables.EllipticCurveForClient);
            ECIESUnprocessResult unprocessResult = ECIESProvider.unprocessMessage(sharedKey.x.ToString(),
                loginContainer.loginPackage.Tag, loginContainer.loginPackage.EncryptedMessage);

            if (unprocessResult.Status != MyEnum.Successful)
            {
                return JsonSerializer.Serialize(new LoginResultContainer()
                {
                    LoginResultECIESProcessed = ECIESProvider.processMessage(sharedKey.x.ToString(),
                        JsonSerializer.Serialize(new LoginResult()
                        {
                            Status = 401
                        }))
                });
            }
            else
            {
                LoginPackage loginPackage =
                    JsonSerializer.Deserialize<LoginPackage>(unprocessResult.DeprocessedMessage);
                LoginResult loginResult = _login.login(loginPackage);
                
                return JsonSerializer.Serialize(new LoginResultContainer()
                {
                    LoginResultECIESProcessed = ECIESProvider.processMessage(sharedKey.x.ToString(),
                        JsonSerializer.Serialize(loginResult))
                });
            }
        }


        private string getInitialPackage()
        {
            InitialPackage initialPackage = EncryptionVariables.initialPackage;
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new BigIntegerConverter());
            string initialPackageJson = JsonSerializer.Serialize(initialPackage, serializerOptions);

            Signature signature = Signing.signMessage(initialPackageJson, EncryptionVariables.EllipticCurveForClient,
                EncryptionVariables.PrkcForClient);
            InitialPackageContainer container = new InitialPackageContainer()
                {initialPackage = initialPackage, signature = signature};

            return JsonSerializer.Serialize(container, serializerOptions);
        }

        //
        // private string returnMessage(string serialized, EllipticCurvePoint ClientPuk)
        // {
        //     EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(EncryptionVariables.PrkcForClient,
        //         ClientPuk,
        //         EncryptionVariables.EllipticCurveForClient);
        //     byte[] Kenc = KDF.DeriveKey(Encoding.ASCII.GetBytes(sharedKey.x.ToString()), KDF.DefaultRoundsEnc);
        //     byte[] Kmac = KDF.DeriveKey(Encoding.ASCII.GetBytes(sharedKey.x.ToString()), KDF.DefaultRoundsMac);
        //
        //     byte[] encryptedMessage = new AesEncryptionProvider(Kenc).Encrypt(serialized, Kenc);
        //     byte[] signedMessage = MAC.GetTag(encryptedMessage, Kmac);
        //
        //     return Encoding.ASCII.GetString(signedMessage);
        // }


        // private string clientLoginNotAllowed()
        // {
        //     return JsonSerializer.Serialize(new LoginResult()
        //     {
        //         Status = 401
        //     });
        // }


        // Signature signature = JsonSerializer.Deserialize<Signature>(message, serializerOptions);
        //
        // string loginFormSerialized = Verifying.getContentOfVerifiedSignature(signature);
        // LoginPackage loginForm = JsonSerializer.Deserialize<LoginPackage>(loginFormSerialized);
        //
        // NIOSLoginResult niosLoginResult = _login.login(loginForm.EncryptedCredentials);
        // if (niosLoginResult.Status.Equals(200))
        // {
        //     string token = niosLoginResult.Token;
        //     string deviceToken = PrivateKeyGenerator.generatePrivateKey().ToString();
        //
        //     // to be changed later to actual storage
        //     _subscribers.Add(deviceToken, loginForm.ClientPuk);
        //
        //     LoginResult result = new LoginResult()
        //     {
        //         Status = 200,
        //         DeviceToken = deviceToken,
        //         VoteToken = token,
        //         Choices = getElectionData()
        //     };
        //
        //     return returnMessage(JsonSerializer.Serialize(result), loginForm.ClientPuk);
        // }
        // return JsonSerializer.Serialize(new LoginResult()
        // {
        //     Status = 401,
        // });


        //
        // [HttpPost]
        // [Route("/logout/{deviceToken}")]
        // public string logout([FromBody] string message, string deviceToken)
        // {
        //     EllipticCurvePoint clientPuk = getPuK(deviceToken);
        //
        //     EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(
        //         EncryptionVariables.PrkcForClient, clientPuk,
        //         EncryptionVariables.EllipticCurveForClient);
        //     byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());
        //
        //     AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
        //     byte[] Kenc = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
        //     byte[] Kmac = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);
        //
        //     if (MAC.VerifyTag(Encoding.ASCII.GetBytes(message), Kmac))
        //     {
        //         byte[] encryptedContent = MAC.extractEncryptedContent(Encoding.ASCII.GetBytes(message), Kmac);
        //         string token = aes.Decrypt(encryptedContent, Kenc);
        //
        //         NIOSLoginResult NIOSlogout = _login.logout(token);
        //
        //         LoginResult result = new()
        //         {
        //             Status = NIOSlogout.Status
        //         };
        //
        //         string resultJson = JsonSerializer.Serialize(result);
        //
        //         byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
        //         byte[] signedData = MAC.GetTag(encryptedData, Kmac);
        //
        //         return Encoding.ASCII.GetString(signedData);
        //     }
        //
        //     return "Message is invalid";
        // }


        // [HttpPost]
        // [Route("/vote/{deviceToken}")]
        // public string vote([FromBody] string message, string deviceToken)
        // {
        //     EllipticCurvePoint clientPuk = getPuK(deviceToken);
        //
        //     EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(
        //         EncryptionVariables.PrkcForClient, clientPuk,
        //         EncryptionVariables.EllipticCurveForClient);
        //     byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());
        //
        //     AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
        //     byte[] Kenc = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
        //     byte[] Kmac = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);
        //
        //     if (MAC.VerifyTag(Encoding.ASCII.GetBytes(message), Kmac))
        //     {
        //         byte[] encryptedVote = MAC.extractEncryptedContent(Encoding.ASCII.GetBytes(message), Kmac);
        //         string voteSerialized = aes.Decrypt(encryptedVote, Kenc);
        //
        //         Vote vote = JsonSerializer.Deserialize<Vote>(voteSerialized);
        //         VoteResult result = placeVote(vote);
        //
        //         string resultJson = JsonSerializer.Serialize(result);
        //
        //         byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
        //         byte[] signedData = MAC.GetTag(encryptedData, Kmac);
        //
        //         return Encoding.ASCII.GetString(signedData);
        //     }
        //
        //     return "Message is invalid";
        // }
        //
        // private VoteResult placeVote(Vote vote1)
        // {
        //     return new() {Status = 200};
        // }
        //
        // private EllipticCurvePoint getPuK(string deviceToken)
        // {
        //     EllipticCurvePoint clientPuk = _subscribers[deviceToken];
        //     return clientPuk;
        // }
        //
        // private void registerDevice(string deviceToken, EllipticCurvePoint loginFormClientPuk)
        // {
        //     _subscribers.Add(deviceToken, loginFormClientPuk);
        // }
        //
        // private string getNewDeviceToken()
        // {
        //     return PrivateKeyGenerator.generatePrivateKey().ToString();
        // }
        //
        // private string getContent(string message)
        // {
        //     return message;
        // }
        //
        // private bool verifySignature(byte[] message, byte[] key)
        // {
        //     return true;
        // }
        //
        // private List<string> getElectionChoices()
        // {
        //     List<string> list = new List<string>();
        //     list.Add("Donald Trump");
        //     list.Add("Hillary Clinton");
        //     list.Add("Barrack Obama");
        //
        //     return list;
        // }
    }


    // if (verifySignature(Encoding.ASCII.GetBytes(message),
    //     Encoding.ASCII.GetBytes(EncryptionVariables.PrkcForClient.ToString())))
    // {
    //     message = getContent(message);
    //     LoginForm loginForm = JsonSerializer.Deserialize<LoginForm>(message);
    //
    //     if (loginForm != null)
    //     {
    //         EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(
    //             EncryptionVariables.PrkcForClient, loginForm.ClientPuk,
    //             EncryptionVariables.EllipticCurveForClient);
    //         byte[] sharedKeyBytesX = Encoding.ASCII.GetBytes(sharedKey.x.ToString());
    //
    //         AesEncryptionProvider aes = new AesEncryptionProvider(sharedKeyBytesX);
    //         byte[] Kenc = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsEnc);
    //         byte[] Kmac = KDF.DeriveKey(sharedKeyBytesX, KDF.DefaultRoundsMac);
    //
    //         NIOSLoginResult NIOSLogin = _login.login(loginForm.EncryptedCredentials);
    //         LoginResult result;
    //         if (NIOSLogin.Status.Equals(200))
    //         {
    //             string deviceToken = getNewDeviceToken();
    //             registerDevice(deviceToken, loginForm.ClientPuk);
    //             result = new()
    //             {
    //                 DeviceToken = deviceToken,
    //                 VoteToken = NIOSLogin.Token,
    //                 Status = 200,
    //                 Choices = getElectionChoices()
    //             };
    //         }
    //         else
    //         {
    //             result = new()
    //             {
    //                 Status = 401
    //             };
    //         }
    //
    //         string resultJson = JsonSerializer.Serialize(result);
    //
    //         byte[] encryptedData = aes.Encrypt(resultJson, Kenc);
    //         byte[] signedData = MAC.GetTag(encryptedData, Kmac);
    //
    //         return Encoding.ASCII.GetString(signedData);
    //     }
    // }
    //
    // return "Message is invalid";
}