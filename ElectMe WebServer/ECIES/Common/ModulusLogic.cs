using System.Numerics;

namespace ElectMe_WebServer.ECIES.Common
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
