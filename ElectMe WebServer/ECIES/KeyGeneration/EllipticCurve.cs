using System.Numerics;
using ElectMe_WebServer.ECIES.util;
using Newtonsoft.Json;

namespace ElectMe_WebServer.ECIES.KeyGeneration
{
   
    public class EllipticCurve
    {
     
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger a { get; set; }
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger b { get; set; }
        public EllipticCurvePoint G { get; set; }
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger p { get; set; }
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger n { get; set; }
        [JsonConverter(typeof(BigIntegerConverter))] public BigInteger h { get; set; }
    }
}
