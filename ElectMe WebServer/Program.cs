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

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}