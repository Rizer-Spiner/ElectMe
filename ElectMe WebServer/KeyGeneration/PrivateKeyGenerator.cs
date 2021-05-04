using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace ElectMe_WebServer.KeyGeneration
{
    class PrivateKeyGenerator
    {
        public static BigInteger generatePrivateKey()
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[33];
            rngCryptoServiceProvider.GetBytes(randomBytes, 0, 32);
            randomBytes[32] = 0;
            BigInteger result = new BigInteger(randomBytes);
            return result;
        }
    }
}
