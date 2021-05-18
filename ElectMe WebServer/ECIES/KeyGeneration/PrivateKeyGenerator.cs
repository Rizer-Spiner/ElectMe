using System.Numerics;
using System.Security.Cryptography;

namespace ElectMe_WebServer.ECIES.KeyGeneration
{
    class PrivateKeyGenerator
    {
        public static BigInteger generatePrivateKey()
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[33];
            rngCryptoServiceProvider.GetBytes(randomBytes, 0, 32);
            randomBytes[32] = 0;
            return new BigInteger(randomBytes);
        }
    }
}
