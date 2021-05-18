using ElectMe_WebServer.ECIES.KeyGeneration;

namespace ElectMe_WebServer.Models
{
    public class LoginForm
    {
        public EllipticCurvePoint ClientPuk { get; set; }
        public string EncryptedCredentials { get; set; }
    }
}