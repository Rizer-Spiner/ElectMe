using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ElectMe_WebServer.KeyGeneration
{
    public class EllipticCurve
    {
        public BigInteger a { get; set; }
        public BigInteger b { get; set; }
        public EllipticCurvePoint G { get; set; }
        public BigInteger p { get; set; }
        public BigInteger n { get; set; }
        public BigInteger h { get; set; }
    }
}
