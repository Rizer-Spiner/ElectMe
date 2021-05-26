using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.util;

namespace ElectMe_WebClient.Models
{
    public class LoginContainer
    {
        // public string encryptedLoginPackage { get; set; }
        // public EllipticCurvePoint clientPuk { get; set; }
        // public byte[] tag { get; set; }
        
        public EllipticCurvePoint clientPuk { get; set; }
        public ECIESProcessResult loginPackage { get; set; }
    }
}
