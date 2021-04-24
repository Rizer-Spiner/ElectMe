using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ElectMe_WebServer.ECIES.util
{
    public class KDF
    {
       
        public static readonly int DefaultRoundsEnc = 2;
        public static readonly int DefaultRoundsMac = 3;
        
        public byte[] DeriveKey(byte[] sharedKey, int rounds)
        {
            
            if (sharedKey == null || sharedKey.Length <= 0)
                throw new ArgumentNullException("Key");
            if (rounds < 0)
                throw new ArgumentException("Rounds has to be greater than 0");

            byte[] hashedkey = new byte[256];
            hashedkey = HKDF.DeriveKey(HashAlgorithmName.SHA256, sharedKey, sharedKey.Length);

            for (int i = 0; i < rounds; i++)
            {
                hashedkey = HKDF.DeriveKey(HashAlgorithmName.SHA256, hashedkey, sharedKey.Length);
            }
            return hashedkey;
        }
        
    }
}