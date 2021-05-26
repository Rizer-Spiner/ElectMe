using System.Net.Http;
using ElectMe_WebClient.ECIES;
using ElectMe_WebClient.ECIES.ECDSA;
using ElectMe_WebClient.ECIES.KeyGeneration;
using ElectMe_WebClient.ECIES.util;
using ElectMe_WebClient.HTTP;
using ElectMe_WebClient.Models;
using System.Text.Json;
using System.Threading.Tasks;
using ElectMe_WebClient.ECIES.Common.ECC;


namespace ElectMe_WebClient.Services
{
    public class LoginService
    {
        public async Task<bool> initializeEncryptionVariables()
        {
            string response = await new HttpRequester().RetrieveMessage("/connect");

            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new BigIntegerConverter());
            InitialPackageContainer initialPackageContainer = JsonSerializer.Deserialize<InitialPackageContainer>(
                response,
                serializerOptions);

            if (!Verifying.verifyMessage(initialPackageContainer.signature, JsonSerializer.Serialize(
                    initialPackageContainer.initialPackage, serializerOptions),
                initialPackageContainer.initialPackage.ServerPuk,
                initialPackageContainer.initialPackage.EllipticCurve))
                return false;

            ClientVariables.Puk = KeyGeneration.calculatePublicKey(
                ClientVariables.Prk, initialPackageContainer.initialPackage.EllipticCurve);
            ClientVariables.SharedKey = KeyGeneration.calculateMasterKey(
                ClientVariables.Prk, initialPackageContainer.initialPackage.ServerPuk,
                initialPackageContainer.initialPackage.EllipticCurve);
            ClientVariables.EllipticCurve = initialPackageContainer.initialPackage.EllipticCurve;
            ClientVariables.NiosKey = initialPackageContainer.initialPackage.NiosKey;
            return true;
        }


        public async Task<MyEnum> sendLoginRequest(Credentials identity)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new BigIntegerConverter());

            EllipticCurvePoint niosSharedKey = KeyGeneration.calculateMasterKey(
                ClientVariables.Prk,
                ClientVariables.NiosKey,
                ClientVariables.EllipticCurve);

            string message = JsonSerializer.Serialize(identity);
            NIOSPackage NIOSPackage = new()
            {
                clientPUk = ClientVariables.Puk,
                encryptedCredentials = ECIESProvider.processMessage(niosSharedKey.x.ToString(), message)
            };

            LoginPackage loginPackage = new()
            {
                Cpr = identity.Cpr,
                niosPackage = NIOSPackage
            };

            LoginContainer loginContainer = new()
            {
                clientPuk = ClientVariables.Puk,
                loginPackage = ECIESProvider.processMessage(ClientVariables.SharedKey.x.ToString(),
                    JsonSerializer.Serialize(loginPackage, serializerOptions))
            };

            string loginContainerString = JsonSerializer.Serialize(loginContainer, serializerOptions);
            HttpResponseMessage responseLoginResult =
                await new HttpRequester().PostMessage(loginContainerString, "/login");


            string loginResultString = responseLoginResult.Content.ReadAsStringAsync().Result;
            LoginResultContainer resultContainer = JsonSerializer.Deserialize<LoginResultContainer>(loginResultString);

            ECIESUnprocessResult unprocessResult = ECIESProvider.unprocessMessage(
                ClientVariables.SharedKey.x.ToString(),
                resultContainer.LoginResultECIESProcessed.Tag,
                resultContainer.LoginResultECIESProcessed.EncryptedMessage);

            if (unprocessResult.Status != MyEnum.Successful)
                return MyEnum.Unauthorized;
            LoginResult result = JsonSerializer.Deserialize<LoginResult>(unprocessResult.DeprocessedMessage);
            if (result.Status != 200)
                return MyEnum.Fail;
            else
                return MyEnum.Successful;
        }
    }
}