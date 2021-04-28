using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ElectMe_WebServer.KeyGeneration
{
    public class PointDoubling
    {
        public static EllipticCurvePoint doublePoint(EllipticCurve curve, EllipticCurvePoint point)
        {
            BigInteger xResult = calculateX(curve, point);
            return new EllipticCurvePoint { x = xResult, y = calculateY(curve, point, xResult) };
        }

        /*---------------------------------------------------------------------------------------------------------------------------
        X
        ---------------------------------------------------------------------------------------------------------------------------*/

        private static BigInteger calculateX(EllipticCurve curve, EllipticCurvePoint point)
        {
            return ModulusLogic.convertToModulus((calculateXNumerator(curve, point) * calculateXDenominator(curve, point)), curve.n);
        }

        private static BigInteger calculateXNumerator(EllipticCurve curve, EllipticCurvePoint point)
        {
            BigInteger xNumerator = 9 * point.x * point.x * point.x * point.x + 6 * curve.a * point.x * point.x + curve.a * curve.a - 8 * point.x * point.y * point.y;
            return ModulusLogic.convertToModulus(xNumerator, curve.n);
        }

        private static BigInteger calculateXDenominator(EllipticCurve curve, EllipticCurvePoint point)
        {
            BigInteger xDenominator = 4 * point.y * point.y;
            return ModulusLogic.inverseModuloN(ModulusLogic.convertToModulus(xDenominator, curve.n), curve.n);
        }

        /*---------------------------------------------------------------------------------------------------------------------------
        Y
        ---------------------------------------------------------------------------------------------------------------------------*/

        private static BigInteger calculateY(EllipticCurve curve, EllipticCurvePoint point, BigInteger xResult)
        {
            return ModulusLogic.convertToModulus(calculateYNumerator(curve, point, xResult) * calculateYDenominator(curve, point), curve.n);
        }

        private static BigInteger calculateYNumerator(EllipticCurve curve, EllipticCurvePoint point, BigInteger xResult)
        {
            BigInteger yNumerator = (3 * point.x * point.x + curve.a) * (point.x - xResult) - 2 * point.y * point.y;
            return ModulusLogic.convertToModulus(yNumerator, curve.n);
        }

        private static BigInteger calculateYDenominator(EllipticCurve curve, EllipticCurvePoint point)
        {
            BigInteger yDenominator = 2 * point.y;
            return ModulusLogic.inverseModuloN(ModulusLogic.convertToModulus(yDenominator, curve.n), curve.n);
        }
    }
}
