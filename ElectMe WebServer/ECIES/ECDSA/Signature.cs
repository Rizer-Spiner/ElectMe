using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElectMe_WebServer.ECIES.ECDSA
{
    public class Signature
    {
        public BigInteger r { get; set; }
        public BigInteger s { get; set; }
    }
}
