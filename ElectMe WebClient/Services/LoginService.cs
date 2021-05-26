using ElectMe_WebClient.ECIES;
using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.ECDSA;
using ElectMe_WebClient.ECIES.KeyGeneration;
using ElectMe_WebClient.ECIES.util;
using ElectMe_WebClient.HTTP;
using ElectMe_WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElectMe_WebClient.Services
{
    public class LoginService
    {
        public async Task<bool> initializeEncryptionVariables()
        {
            string response = await new HttpRequester().RetrieveMessage("/connect");

            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new BigIntegerConverter());
            InitialPackageContainer initialPackageContainer = JsonSerializer.Deserialize<InitialPackageContainer>(response, serializerOptions);

            if (!Verifying.verifyMessage(initialPackageContainer.signature, JsonSerializer.Serialize(initialPackageContainer.initialPackage, serializerOptions), initialPackageContainer.initialPackage.ServerPuk, initialPackageContainer.initialPackage.EllipticCurve))
                return false;

            ClientVariables.Puk = KeyGeneration.calculatePublicKey(
                ClientVariables.Prk, initialPackageContainer.initialPackage.EllipticCurve);
            EllipticCurvePoint sharedKey = KeyGeneration.calculateMasterKey(
                ClientVariables.Prk, initialPackageContainer.initialPackage.ServerPuk, initialPackageContainer.initialPackage.EllipticCurve);
            ClientVariables.EllipticCurve = initialPackageContainer.initialPackage.EllipticCurve;
            ClientVariables.NiosKey = initialPackageContainer.initialPackage.NiosKey;
            return true;
        }
    }
}
