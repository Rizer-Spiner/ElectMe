using System;
using System.Security.Cryptography;

namespace ElectMe_WebServer.ECIES.util
{
    public class KDF
    {
        public static readonly int DefaultRoundsEnc = 2;
        public static readonly int DefaultRoundsMac = 3;

        public static byte[] DeriveKey(byte[] sharedKey, int rounds)
        {
            if (sharedKey == null || sharedKey.Length <= 0)
                throw new ArgumentNullException("Key");
            if (rounds < 0)
                throw new ArgumentException("Rounds has to be greater than 0");

            byte[] hashedkey;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] key = sha256Hash.ComputeHash(sharedKey);

                hashedkey = new byte[32];
                for (int i = 0; i < rounds; i++)
                {
                    hashedkey = HKDF.DeriveKey(HashAlgorithmName.SHA256, hashedkey, hashedkey.Length);
                }
            }

            return hashedkey;
        }
    }
}