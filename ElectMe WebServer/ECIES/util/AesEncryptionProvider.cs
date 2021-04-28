using System.IO;
using System.Security.Cryptography;

namespace ElectMe_WebServer.ECIES.util
{
    public class AesEncryptionProvider
    {
        public Encryptor Encryptor;
        public Decryptor Decryptor;

        public AesEncryptionProvider(byte[] IV)
        {
            byte[] IV16 = new byte[16];
            for (int i = 0; i < IV16.Length; i++)
            {
                IV16[i] = IV[i];
            }
            
            Encryptor = new Encryptor(IV16);
            Decryptor = new Decryptor(IV16);
        }


        public byte[] Encrypt(string plainText, byte[] Key)
        {
            return Encryptor.EncryptStringToBytes_Aes(plainText, Key);
        }

        public string Decrypt(byte[] cipherText, byte[] Key)
        {
            return Decryptor.DecryptStringFromBytes_Aes(cipherText, Key);
        }
    }
}