using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElectMe_WebClient.ECIES.ECDSA
{
    public class Signature
    {
        public BigInteger r { get; set; }
        public BigInteger s { get; set; }
    }
}
