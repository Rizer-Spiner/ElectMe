using System.Text;

namespace ElectMe_WebServer.ECIES.util
{
    public class ECIESProvider
    {
        public static ECIESProcessResult processMessage(string key, string message)
        {
            byte[] sharedKey = Encoding.ASCII.GetBytes(key);
            byte[] Kenc = KDF.DeriveKey(sharedKey, KDF.DefaultRoundsEnc);
            byte[] Kmac = KDF.DeriveKey(sharedKey, KDF.DefaultRoundsMac);

            AesEncryptionProvider aes = new AesEncryptionProvider(Kenc);
            byte[] encryptedMessage = aes.Encrypt(message, Kenc);
            byte[] signedMessage = MAC.GetTag(encryptedMessage, Kmac);

            return new()
            {
                Tag = Encoding.ASCII.GetString(signedMessage),
                EncryptedMessage = Encoding.ASCII.GetString(encryptedMessage)
            };
        }


        public static ECIESUnprocessResult unprocessMessage(string key, string tag, string message)
        {
            byte[] sharedKey = Encoding.ASCII.GetBytes(key);
            byte[] Kenc = KDF.DeriveKey(sharedKey, KDF.DefaultRoundsEnc);
            byte[] Kmac = KDF.DeriveKey(sharedKey, KDF.DefaultRoundsMac);

            AesEncryptionProvider aes = new AesEncryptionProvider(Kenc);

            byte[] tagByte = Encoding.ASCII.GetBytes(tag);
            byte[] messageByte = Encoding.ASCII.GetBytes(message);
            if (MAC.VerifyTag(tagByte, Kmac))

                return new()
                {
                    DeprocessedMessage = aes.Decrypt(messageByte, Kenc),
                    Status = MyEnum.Successful
                };
            else
                return new()
                {
                    DeprocessedMessage = "",
                    Status = MyEnum.Fail
                };
        }
    }

    public class ECIESUnprocessResult
    {
        public MyEnum Status { get; set; }
        public string DeprocessedMessage { get; set; }
    }

    public class ECIESProcessResult
    {
        public string Tag { get; set; }
        public string EncryptedMessage { get; set; }
    }

    public enum MyEnum
    {
        Successful,
        Fail,
        Unauthorized
    }
}