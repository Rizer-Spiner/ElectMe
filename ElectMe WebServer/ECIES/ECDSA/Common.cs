using System.Collections;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using ElectMe_WebServer.ECIES.Common.ECC;
using BitOperations = ElectMe_WebServer.ECIES.Common.BitOperations;

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
            hashBitArray.RightShift(hashBitArray.Length - BitOperations.getBits(theCurve.p).Length);
            hashBitArray.CopyTo(bytes, 0);
            return new BigInteger(bytes);
        }
    }
}
