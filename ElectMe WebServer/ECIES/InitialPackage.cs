using ElectMe_WebServer.ECIES.KeyGeneration;
using Newtonsoft.Json;

namespace ElectMe_WebServer.ECIES
{
   
    public class InitialPackage
    {
        public EllipticCurve EllipticCurve { get; set; }
        public EllipticCurvePoint ServerPuk { get; set; }
        public byte[] CertificateSignature { get; set; }
        public byte[] NiosKey { get; set; }


        public override string ToString()
        {
            return EllipticCurve.a + " " + EllipticCurve.b;
        }
    }
    
}