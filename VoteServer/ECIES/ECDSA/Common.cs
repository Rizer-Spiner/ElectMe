using ElectMe_WebServer.KeyGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace DummyProject.ECDSA
{
    public class Common
    {
        public static byte[] getHash(string message)
        {
            return new SHA512Managed()
                .ComputeHash(
                    Encoding.UTF8.GetBytes(message)
                );
        }

        public static BigInteger computeZ(byte[] bytes, EllipticCurve theCurve)
        {
            BitArray hashBitArray = new BitArray(bytes);
            hashBitArray.RightShift(hashBitArray.Length - DummyProject.Common.BitOperations.getBits(theCurve.p).Length);
            hashBitArray.CopyTo(bytes, 0);
            return new BigInteger(bytes);
        }
    }
}
