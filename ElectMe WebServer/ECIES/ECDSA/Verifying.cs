using System.Numerics;
using ElectMe_WebServer.ECIES.Common;
using ElectMe_WebServer.ECIES.Common.ECC;

namespace ElectMe_WebServer.ECIES.ECDSA
{
    public class Verifying
    {
        public static bool verifyMessage(Signature signature, string message, EllipticCurvePoint publicKey, EllipticCurve theCurve) 
        {
            //step 2+3
            BigInteger z = Common.computeZ(Common.getHash(message), theCurve);
            //step 4
            BigInteger u1 = ModulusLogic.convertToModulus(z * ModulusLogic.inverseModuloN(signature.s, theCurve.p), theCurve.p);
            BigInteger u2 = ModulusLogic.convertToModulus(signature.r * ModulusLogic.inverseModuloN(signature.s, theCurve.p), theCurve.p);
            //step 5
            return getPoint(u1, u2, publicKey, theCurve).x == signature.r;
        }

        private static EllipticCurvePoint getPoint(BigInteger u1, BigInteger u2, EllipticCurvePoint publicKey, EllipticCurve theCurve)
        {
            EllipticCurvePoint GDependentPoint = PointMultiplication.multiplyPoint(u1, theCurve.G, theCurve);
            EllipticCurvePoint PublicKeyDependentPoint = PointMultiplication.multiplyPoint(u2, publicKey, theCurve);
            return PointAddition.addPoints(theCurve, GDependentPoint, PublicKeyDependentPoint);
        }
    }
}
