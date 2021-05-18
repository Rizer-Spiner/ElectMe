using System.Numerics;
using ElectMe_WebClient.ECIES.KeyGeneration;

namespace ElectMe_WebClient.ECIES
{
    public class ClientVariables
    {
        public static BigInteger Prk = PrivateKeyGenerator.generatePrivateKey();
        public static EllipticCurvePoint Puk { get; set; }
        public static byte[] Kenc { get; set; }
        public static byte[] KMac { get; set; }
        public static string DeviceToken { get; set; }
        public static string VoteToken { get; set; }
    }
}