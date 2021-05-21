using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ElectMe_WebClient.ECIES.Common.ECC;

namespace ElectMe_WebClient.ECIES.KeyGeneration
{
    public class KeyGeneration
    {
        public static EllipticCurvePoint calculateMasterKey(BigInteger prk, EllipticCurvePoint theirPublicKey, EllipticCurve curve)
        {
            return PointAddition.addPoints(curve, theirPublicKey, PointMultiplication.multiplyPoint(prk, curve.G, curve));
        }

        public static EllipticCurvePoint calculatePublicKey(BigInteger prk, EllipticCurve curve)
        {
            return PointMultiplication.multiplyPoint(prk, curve.G, curve);
        }
    }
}
