using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ElectMe_WebServer.ECIES.Common
{
    public class BitOperations
    {
        public static int[] getBits(BigInteger n)
        {
            BitArray ba = new BitArray(n.ToByteArray());
            return removePrecedingZeros(ba.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray());
        }

        private static int[] removePrecedingZeros(int[] bits)
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
