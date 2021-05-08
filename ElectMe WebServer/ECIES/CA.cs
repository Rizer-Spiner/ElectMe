using ElectMe_WebServer.KeyGeneration;

namespace ElectMe_WebServer.ECIES
{
    public class CA
    {
        public EllipticCurve EllipticCurve { get; set; }
        public EllipticCurvePoint ServerPuk { get; set; }
        public byte[] CertificateSignature { get; set; }

        public byte[] NiosKey { get; set; }
    }
}