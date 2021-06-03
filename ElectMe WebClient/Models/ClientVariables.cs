using System.Numerics;
using System.Text;
using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.KeyGeneration;

namespace ElectMe_WebClient.ECIES
{
    public class ClientVariables
    {
        public static BigInteger Prk = PrivateKeyGenerator.generatePrivateKey();
        public static EllipticCurvePoint Puk { get; set; }
        public static EllipticCurve EllipticCurve { get; set; }
        public static EllipticCurvePoint NiosKey { get; set; }
        public static string CertificateAuthority = "Certificate Authority signature";

        public static string ElectMeBaseURL = "https://localhost:44352";
       
        public static EllipticCurvePoint SharedKey { get; set; }
        public static string DeviceToken { get; set; }
        public static string VoteToken { get; set; }
    }
}