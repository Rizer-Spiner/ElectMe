using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElectMe_WebClient.ECIES.Common.ECC
{
    public class PointMultiplication
    {
        public static EllipticCurvePoint multiplyPoint(BigInteger prk, EllipticCurvePoint point, EllipticCurve curve)
        {
            if (prk == 0) return new EllipticCurvePoint { x = 0, y = 0 };
            int[] bits = BitOperations.getBits(prk);

            int index = 0;
            EllipticCurvePoint initial = point;
            while (bits[index] == 0)
            {
                initial = PointDoubling.doublePoint(curve, initial);
                index++;
            }

            return getResult(bits, index + 1, curve, initial);
        }

        private static EllipticCurvePoint getResult(int[] bits, int index, EllipticCurve curve, EllipticCurvePoint auxPoint)
        {
            EllipticCurvePoint result = auxPoint;
            while (index < bits.Length)
            {
                auxPoint = PointDoubling.doublePoint(curve, auxPoint);
                if (bits[index] == 1)
                {
                    result = PointAddition.addPoints(curve, result, auxPoint);
                }
                index++;
            }

            return result;
        }
    }
}
