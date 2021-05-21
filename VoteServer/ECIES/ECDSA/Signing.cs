using ElectMe_WebServer.KeyGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using DummyProject.Common;

namespace DummyProject.ECDSA
{
    public class Signing
    {
        public static Signature signMessage(string message, EllipticCurve theCurve, BigInteger privateKey)
        {
            //step 1+2
            BigInteger z = Common.computeZ(Common.getHash(message), theCurve);
            BigInteger k = computeK(theCurve);
            BigInteger r;
            while((r = computePoint(k, theCurve).x) == 0)
            {
                k = computeK(theCurve);
            }
            BigInteger s;
            while ((s = calculateS(privateKey, k, z, r, theCurve)) == 0)
            {
                k = computeK(theCurve);
            }
            return new Signature() { r = r, s = s };
        }

        //step 3
        private static BigInteger computeK(EllipticCurve theCurve)
        {
            BigInteger k = PrivateKeyGenerator.generatePrivateKey();
            while (k >= theCurve.p)
            {
                k = PrivateKeyGenerator.generatePrivateKey();
            }
            return k;
        }

        //step 4
        private static EllipticCurvePoint computePoint(BigInteger k, EllipticCurve theCurve)
        {
            return PointMultiplication.multiplyPoint(k, theCurve.G, theCurve);
        }

        //step 6
        private static BigInteger calculateS(BigInteger privateKey, BigInteger k, BigInteger z, BigInteger r, EllipticCurve theCurve)
        {
            BigInteger inverseK = ModulusLogic.inverseModuloN(k, theCurve.p);
            return ModulusLogic.convertToModulus(inverseK * (z + (r * privateKey)), theCurve.p);
        }
    }
}
