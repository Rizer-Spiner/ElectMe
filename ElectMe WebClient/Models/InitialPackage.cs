using ElectMe_WebClient.ECIES.Common.ECC;

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