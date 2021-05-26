using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.KeyGeneration;
using Newtonsoft.Json;

namespace ElectMe_WebClient.ECIES
{
    public class InitialPackage
    {
        public EllipticCurve EllipticCurve { get; set; }
        public EllipticCurvePoint ServerPuk { get; set; }
        public EllipticCurvePoint NiosKey { get; set; }
        public string CA { get; set; }
    }
}