using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ElectMe_WebServer.KeyGeneration
{
    public class PointAddition
    {
        public static EllipticCurvePoint addPoints(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            BigInteger xResult = calculateX(curve, point1, point2);
            return new EllipticCurvePoint { x = xResult, y = calculateY(curve, point1, point2, xResult) };
        }

        /*---------------------------------------------------------------------------------------------------------------------------
        X
        ---------------------------------------------------------------------------------------------------------------------------*/

        private static BigInteger calculateX(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            return ModulusLogic.convertToModulus(calculateXNumerator(curve, point1, point2) * calculateXDenominator(curve, point1, point2), curve.n);
        }

        private static BigInteger calculateXNumerator(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            BigInteger xNumerator = (point2.y - point1.y) * (point2.y - point1.y) - (point1.x + point2.x) * (point2.x - point1.x) * (point2.x - point1.x);
            return ModulusLogic.convertToModulus(xNumerator, curve.n);
        }

        private static BigInteger calculateXDenominator(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            BigInteger xDenominator = (point2.x - point1.x) * (point2.x - point1.x);
            return ModulusLogic.inverseModuloN(ModulusLogic.convertToModulus(xDenominator, curve.n), curve.n);
        }

        /*---------------------------------------------------------------------------------------------------------------------------
        Y
        ---------------------------------------------------------------------------------------------------------------------------*/

        private static BigInteger calculateY(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2, BigInteger xResult)
        {
            return ModulusLogic.convertToModulus(calculateYNumerator(curve, point1, point2, xResult) * calculateYDenominator(curve, point1, point2), curve.n);
        }

        private static BigInteger calculateYNumerator(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2, BigInteger xResult)
        {
            BigInteger yNumerator = (point2.y - point1.y) * (point1.x - xResult) - point1.y * (point2.x - point1.x);
            return ModulusLogic.convertToModulus(yNumerator, curve.n);
        }

        private static BigInteger calculateYDenominator(EllipticCurve curve, EllipticCurvePoint point1, EllipticCurvePoint point2)
        {
            BigInteger yDenominator = point2.x - point1.x;
            return ModulusLogic.inverseModuloN(ModulusLogic.convertToModulus(yDenominator, curve.n), curve.n);
        }
    }
}
