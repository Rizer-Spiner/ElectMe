﻿
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ElectMe_WebServer.KeyGeneration
{
    public class KeyGeneration
    {
        public static EllipticCurvePoint calculatePublicKey(BigInteger prk, EllipticCurve curve)
        {
            if (prk == 0) return new EllipticCurvePoint { x = 0, y = 0 };
            int[] bits = getBits(prk);

            int index = 0;
            EllipticCurvePoint initial = curve.G;
            while (bits[index] == 0)
            {
                initial = PointDoubling.doublePoint(curve, curve.G);
                index++;
            }

            return getResult(bits, index + 1, curve, initial);
        }

        public static EllipticCurvePoint calculateSharedKey(BigInteger ownPrk, EllipticCurvePoint otherPuK, EllipticCurve curve)
        {
            if (ownPrk == 0) return new EllipticCurvePoint { x = 0, y = 0 };
            int[] bits = getBits(ownPrk);
            
            int index = 0;
            EllipticCurvePoint initial = otherPuK;
            while (bits[index] == 0)
            {
                initial = PointDoubling.doublePoint(curve, curve.G);
                index++;
            }

            return getResult(bits, index + 1, curve, initial);
        }

        private static int[] getBits(BigInteger n)
        {
            BitArray ba = new BitArray(n.ToByteArray());
            return removePrecedingZeros(ba.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray());
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

        public static int[] removePrecedingZeros(int[] bits)
        {
            List<int> bitList = bits.ToList();
            int i = bitList.Count - 1;
            while (bitList[i] == 0)
            {
                bitList.RemoveAt(i);
                i--;
            }
            return bitList.ToArray();
        }
    }
}