using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.KeyGeneration;

namespace ElectMe_WebServer.Models
{
    public class LoginForm
    {
        public EllipticCurvePoint ClientPuk { get; set; }
        public byte[] EncryptedCredentials { get; set; }
        public byte[] HashedCPR { get; set; }
    }
}