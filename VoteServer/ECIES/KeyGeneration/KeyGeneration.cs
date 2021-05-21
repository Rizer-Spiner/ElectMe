using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using DummyProject.Common;

namespace ElectMe_WebServer.KeyGeneration
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
