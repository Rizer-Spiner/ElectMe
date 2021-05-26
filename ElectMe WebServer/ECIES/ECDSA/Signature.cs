using System.Numerics;

namespace ElectMe_WebServer.ECIES.ECDSA
{
    public class Signature
    {
        public BigInteger r { get; set; }
        public BigInteger s { get; set; }
    }
}
