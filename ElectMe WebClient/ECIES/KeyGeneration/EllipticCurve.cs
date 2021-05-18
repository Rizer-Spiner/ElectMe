using System;
using System.Numerics;
using ElectMe_WebClient.ECIES.util;
using Newtonsoft.Json;


namespace ElectMe_WebClient.ECIES.KeyGeneration
{
    public class EllipticCurve
    {
        [JsonProperty("a")]
        [JsonConverter(typeof(BigIntegerConverter))]
        public BigInteger a { get; set; }

        [JsonProperty("b")]
        [JsonConverter(typeof(BigIntegerConverter))]
        public BigInteger b { get; set; }

        [JsonProperty("G")] 
        public EllipticCurvePoint G { get; set; }

        [JsonProperty("p")]
        [JsonConverter(typeof(BigIntegerConverter))]
        public BigInteger p { get; set; }

        [JsonProperty("n")]
        [JsonConverter(typeof(BigIntegerConverter))]
        public BigInteger n { get; set; }

        [JsonProperty("h")]
        [JsonConverter(typeof(BigIntegerConverter))]
        public BigInteger h { get; set; }
    }
}