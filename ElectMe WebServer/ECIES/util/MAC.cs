using System.IO;
using System.Security.Cryptography;

namespace ElectMe_WebServer.ECIES.util
{
    public class MAC
    {
        public static byte[] GetTag(byte[] encryptedMessage, byte[] Kmac)
        {
            using (var hashMac256 = new HMACSHA256(Kmac))
            {
                byte[] hash = hashMac256.ComputeHash(encryptedMessage);

                byte[] Tag = new byte[hash.Length + encryptedMessage.Length];

                for (int i = 0; i < hash.Length; i++)
                {
                    Tag[i] = hash[i];
                }

                for (int i = hash.Length; i < (hash.Length + encryptedMessage.Length); i++)
                {
                    Tag[i] = encryptedMessage[i - hash.Length];
                }

                return Tag;
            }
        }


        public static bool VerifyTag(byte[] message, byte[] KMac)
        {
            using (HMACSHA256 hmac = new HMACSHA256(KMac))
            {
                byte[] storedHash = new byte[hmac.HashSize / 8];

                for (int i = 0; i < storedHash.Length; i++)
                {
                    storedHash[i] = message[i];
                }

                byte[] messageContent = new byte[message.Length - storedHash.Length];
                for (int i = 0; i < message.Length - storedHash.Length; i++)
                {
                    messageContent[i] = message[i + storedHash.Length];
                }

                byte[] computedHash = hmac.ComputeHash(messageContent);

                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static byte[] extractEncryptedContent(byte[] signedMessage, byte[] KMac)
        {
            using (HMACSHA256 hmac = new HMACSHA256(KMac))
            {
                byte[] storedHash = new byte[hmac.HashSize / 8];

                for (int i = 0; i < storedHash.Length; i++)
                {
                    storedHash[i] = signedMessage[i];
                }

                byte[] messageContent = new byte[signedMessage.Length - storedHash.Length];
                for (int i = 0; i < signedMessage.Length - storedHash.Length; i++)
                {
                    messageContent[i] = signedMessage[i + storedHash.Length];
                }

                return messageContent;
            }
        }
    }
}