using ElectMe_WebClient.ECIES.KeyGeneration;
using Newtonsoft.Json;

namespace ElectMe_WebClient.ECIES
{
    
    public class InitialPackage
    {
        
        //todo change name to InitialPackage 
        
        [JsonProperty("EllipticCurve")]
        public EllipticCurve EllipticCurve { get; set; }
        [JsonProperty("ServerPuk")]public EllipticCurvePoint ServerPuk { get; set; }
        [JsonProperty("CertificateSignature")] public byte[] CertificateSignature { get; set; }

        [JsonProperty("NiosKey")]public byte[] NiosKey { get; set; }
    }
}