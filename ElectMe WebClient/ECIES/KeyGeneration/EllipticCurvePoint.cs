using System;
using System.Numerics;
using ElectMe_WebClient.ECIES.util;
using Newtonsoft.Json;


namespace ElectMe_WebClient.ECIES.KeyGeneration
{
   
    public class EllipticCurvePoint
    {
        [JsonProperty("x")][JsonConverter(typeof(BigIntegerConverter))] public BigInteger x { get; set; }
        [JsonProperty("y")][JsonConverter(typeof(BigIntegerConverter))] public BigInteger y { get; set; }
    }
}