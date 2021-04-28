using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ElectMe_WebServer.ECIES.util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElectMe_WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String key = "&E)H@McQeThWmZq4t7w!z%C*F-JaNdRg";
            // String key = "HR$2pIjHR$2pIj12";
            byte[] keyByte = Encoding.ASCII.GetBytes(key);

            String originalMessage = "This is a very important message!";
            Console.WriteLine("Original message: " + originalMessage);

            KDF kdf = new KDF();
            AesEncryptionProvider aesEncryptionProvider = new AesEncryptionProvider(keyByte);

            byte[] Kenc = kdf.DeriveKey(keyByte, KDF.DefaultRoundsEnc);
            Console.WriteLine("Encryption key: " + Encoding.ASCII.GetString(Kenc));

            byte[] KMac = kdf.DeriveKey(keyByte, KDF.DefaultRoundsMac);
            Console.WriteLine("HMAC key: " + Encoding.ASCII.GetString(KMac));


            byte[] encryptedMessage = aesEncryptionProvider.Encrypt(originalMessage, Kenc);
            Console.WriteLine("Encrypted message: " + Encoding.ASCII.GetString(encryptedMessage));

            string decryptedMessage = aesEncryptionProvider.Decrypt(encryptedMessage, Kenc);
            Console.WriteLine("Decrypted message: " + decryptedMessage);


            MAC mac = new MAC();

            byte[] TagMessage = mac.GetTag(encryptedMessage, KMac);
            Console.WriteLine("Tagged message: " + Encoding.ASCII.GetString(TagMessage));

            if (mac.VerifyTag(TagMessage, KMac))
            {
                Console.WriteLine("Tag is correct");
            }
            else
            {
                Console.WriteLine("Tag is incorrect!");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}