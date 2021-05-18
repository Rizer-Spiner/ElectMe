
using System.Numerics;
using ElectMe_WebServer.ECIES.util;
using Newtonsoft.Json;

namespace ElectMe_WebServer.ECIES.KeyGeneration
{
    
    public class EllipticCurvePoint
    {
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger x { get; set; }
        [JsonConverter(typeof(BigIntegerConverter))]public BigInteger y { get; set; }
    }
}
