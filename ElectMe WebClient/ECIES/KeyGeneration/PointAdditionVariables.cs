using System.Numerics;

namespace ElectMe_WebClient.ECIES.KeyGeneration
{
    public class PointAdditionVariables
    {
        //initial point to add to itself
        public EllipticCurvePoint G { get; set; }

        //number of times to add G to itself
        public BigInteger times { get; set; }

        //number of times we already added G to itself
        public BigInteger temp { get; set; }

        //the restult of adding G to itself temp times
        public EllipticCurvePoint currentPoint { get; set; }
    }
}
