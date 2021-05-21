using ElectMe_WebServer.ECIES.Common.ECC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace ElectMe_WebServer.ECIES.ECDSA
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
            hashBitArray.RightShift(hashBitArray.Length - ElectMe_WebServer.ECIES.Common.BitOperations.getBits(theCurve.p).Length);
            hashBitArray.CopyTo(bytes, 0);
            return new BigInteger(bytes);
        }
    }
}
