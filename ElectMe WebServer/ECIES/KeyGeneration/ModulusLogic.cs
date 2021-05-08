using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ElectMe_WebServer.KeyGeneration
{
    public class ModulusLogic
    {
        public static BigInteger convertToModulus(BigInteger number, BigInteger modulus)
        {
            if (number < 0)
                number = modulus - ((modulus - number) % modulus);
            return number % modulus;
        }

        public static BigInteger inverseModuloN(BigInteger number, BigInteger modulus)
        {
            return BigInteger.ModPow(number, modulus - 2, modulus);
        }
    }
}
