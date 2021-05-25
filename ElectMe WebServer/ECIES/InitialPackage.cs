using ElectMe_WebServer.ECIES.Common.ECC;
using Newtonsoft.Json;

namespace ElectMe_WebServer.ECIES
{
   
    public class InitialPackage
    {
        public EllipticCurve EllipticCurve { get; set; }
        public EllipticCurvePoint ServerPuk { get; set; }
        public byte[] NiosKey { get; set; }
        
    }
    
}