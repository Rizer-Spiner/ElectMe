
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace ElectMe_WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // // String key = "&E)H@McQeThWmZq4t7w!z%C*F-JaNdRg";
            // // String key = "HR$2pIjHR$2pIj12";
            // String key =
            //     "04:b4:7a:8d:03:88:b7:0c:3c:74:7b:2f:27:62:15:15:4c:0a:d5:66:9c:c1:ce:ad:80:d8:04:74:5f:75:55:cb:c5:40:dc:ce:3d:45:82:66:ae:ac:3b:84:f3:38:cb:02:1e:b5:58:4d:53:0e:3e:a8:43:fb:99:5e:6d:3d:71:5c:c7";
            // byte[] keyByte = Encoding.ASCII.GetBytes(key);
            //
            // Console.WriteLine("Key lenght: " + keyByte.Length);
            //
            //
            // String originalMessage = "This is a very important message!";
            // Console.WriteLine("Original message: " + originalMessage);
            //
            // KDF kdf = new KDF();
            // AesEncryptionProvider aesEncryptionProvider = new AesEncryptionProvider(keyByte);
            //
            // byte[] Kenc = kdf.DeriveKey(keyByte, KDF.DefaultRoundsEnc);
            // string encryptionKey = Encoding.ASCII.GetString(Kenc);
            // Console.WriteLine("Encryption key: " + encryptionKey);
            // Console.WriteLine(Kenc.Length);
            //
            // byte[] KMac = kdf.DeriveKey(keyByte, KDF.DefaultRoundsMac);
            // string macKey = Encoding.ASCII.GetString(KMac);
            // Console.WriteLine("HMAC key: " + macKey);
            // Console.WriteLine(KMac.Length);
            //
            //
            // byte[] encryptedMessage = aesEncryptionProvider.Encrypt(originalMessage, Kenc);
            // string encryptedMessageString = Encoding.ASCII.GetString(encryptedMessage);
            // Console.WriteLine("Encrypted message: " + encryptedMessageString);
            //
            // string decryptedMessage = aesEncryptionProvider.Decrypt(encryptedMessage, Kenc);
            // Console.WriteLine("Decrypted message: " + decryptedMessage);
            //
            //
            // MAC mac = new MAC();
            //
            // byte[] TagMessage = mac.GetTag(encryptedMessage, KMac);
            // Console.WriteLine("Tagged message: " + Encoding.ASCII.GetString(TagMessage));
            //
            // if (mac.VerifyTag(TagMessage, KMac))
            // {
            //     Console.WriteLine("Tag is correct");
            // }
            // else
            // {
            //     Console.WriteLine("Tag is incorrect!");
            // }

            // BigInteger clientPrK = PrivateKeyGenerator.generatePrivateKey();
            // BigInteger serverPrk = PrivateKeyGenerator.generatePrivateKey();
            //
            // EllipticCurve ellipticCurve = new EllipticCurve
            // {
            //     a = 4,
            //     b = 3,
            //     G = new EllipticCurvePoint {x = 234, y = 121},
            //     n = 180181,
            //     h = 0,
            //     p = 0
            // };
            //
            // EllipticCurvePoint clientPuK = KeyGeneration.KeyGeneration.calculatePublicKey(clientPrK,
            //     ellipticCurve.G, ellipticCurve);
            // EllipticCurvePoint serverPuK = KeyGeneration.KeyGeneration.calculatePublicKey(serverPrk,
            //     ellipticCurve.G, ellipticCurve);
            //
            // EllipticCurvePoint sharedKeyPointClient =
            //     KeyGeneration.KeyGeneration.calculatePublicKey(clientPrK, serverPuK, ellipticCurve);
            // EllipticCurvePoint sharedKeyPointServer =
            //     KeyGeneration.KeyGeneration.calculatePublicKey(serverPrk, clientPuK, ellipticCurve);
            //
            // if (sharedKeyPointClient.x.Equals(sharedKeyPointServer.x) &&
            //     sharedKeyPointClient.y.Equals(sharedKeyPointServer.y))
            // {
            //     Console.WriteLine(sharedKeyPointClient.x);
            //     Console.WriteLine(sharedKeyPointClient.y);
            //     Console.WriteLine("Equals");
            //
            //
            //     BigInteger sharedKey = sharedKeyPointClient.x;
            //     byte[] sharedKeyBytes = Encoding.ASCII.GetBytes(sharedKey.ToString());
            //     Console.WriteLine(sharedKeyBytes.Length);
            //
            //    
            //
            //     AesEncryptionProvider clientAesEncryptionProvider = new AesEncryptionProvider(sharedKeyBytes);
            //     AesEncryptionProvider serverAesEncryptionProvider = new AesEncryptionProvider(sharedKeyBytes);
            //
            //     Console.WriteLine("client sends a message:");
            //     String messageFromClient = "I am a message from the client";
            //     byte[] encryptedMessageFromClient = clientAesEncryptionProvider.Encrypt(messageFromClient,
            //         KDF.DeriveKey(sharedKeyBytes, KDF.DefaultRoundsEnc));
            //     byte[] signedMessage = MAC.GetTag(encryptedMessageFromClient,
            //         KDF.DeriveKey(sharedKeyBytes, KDF.DefaultRoundsMac));
            //     Console.WriteLine(Encoding.ASCII.GetString(signedMessage));
            //
            //     Console.WriteLine("server receives the message");
            //     Console.WriteLine("server verifies signature");
            //     if (MAC.VerifyTag(signedMessage, KDF.DeriveKey(sharedKeyBytes, KDF.DefaultRoundsMac)))
            //     {
            //         Console.WriteLine("Signature verified");
            //         Console.WriteLine("server decrypts message: ");
            //         byte[] encryptedMessage = MAC.extractEncryptedContent(signedMessage,
            //             KDF.DeriveKey(sharedKeyBytes, KDF.DefaultRoundsMac));
            //
            //         string decryptedMessageFromClient = serverAesEncryptionProvider.Decrypt(encryptedMessage,
            //             KDF.DeriveKey(sharedKeyBytes, KDF.DefaultRoundsEnc));
            //
            //         Console.WriteLine(decryptedMessageFromClient);
            //     }
            //     else
            //     {
            //         Console.WriteLine("Signature does not match. Aborted!");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("X:");
            //     Console.WriteLine(sharedKeyPointClient.x);
            //     Console.WriteLine(sharedKeyPointServer.x);
            //     Console.WriteLine("Y:");
            //     Console.WriteLine(sharedKeyPointClient.y);
            //     Console.WriteLine(sharedKeyPointServer.y);
            //     Console.WriteLine("Not equals");
            // }


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}