using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.KeyGeneration;
using Newtonsoft.Json;

namespace ElectMe_WebClient.ECIES
{
    public class InitialPackage
    {
        // [JsonProperty("EllipticCurve")]
        // public EllipticCurve EllipticCurve { get; set; }
        // [JsonProperty("ServerPuk")]public EllipticCurvePoint ServerPuk { get; set; }
        // [JsonProperty("CertificateSignature")] public byte[] CertificateSignature { get; set; }
        //
        // [JsonProperty("NiosKey")]public byte[] NiosKey { get; set; }

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