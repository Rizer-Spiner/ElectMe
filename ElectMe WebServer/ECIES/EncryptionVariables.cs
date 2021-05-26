using ElectMe_WebServer.ECIES.Common.ECC;
using ElectMe_WebServer.ECIES.KeyGeneration;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace ElectMe_WebServer.ECIES
{
    public class EncryptionVariables
    {
        public static readonly EllipticCurve EllipticCurveForClient = new()
        {
            a = BigInteger.Parse("0", NumberStyles.AllowHexSpecifier),
            b = BigInteger.Parse("7", NumberStyles.AllowHexSpecifier),
            G = new EllipticCurvePoint() {
                x = BigInteger.Parse("79BE667EF9DCBBAC55A06295CE870B07029BFCDB2DCE28D959F2815B16F81798", NumberStyles.AllowHexSpecifier), 
                y = BigInteger.Parse("483ADA7726A3C4655DA4FBFC0E1108A8FD17B448A68554199C47D08FFB10D4B8", NumberStyles.AllowHexSpecifier)
            },
            n = BigInteger.Parse("0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F", NumberStyles.AllowHexSpecifier),
            h = 0,
            p = BigInteger.Parse("0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141", NumberStyles.AllowHexSpecifier)
        };

        public static readonly BigInteger PrkcForClient = PrivateKeyGenerator.generatePrivateKey();

        public static readonly EllipticCurvePoint PukForClients = KeyGeneration.KeyGeneration.calculatePublicKey(
            PrkcForClient,
            EllipticCurveForClient);

        public static readonly string CertificateAuthority ="Certificate Authority signature";

        public static readonly InitialPackage initialPackage = new()
        {
            EllipticCurve = EllipticCurveForClient,
            ServerPuk = PukForClients,
            NiosKey = new EllipticCurvePoint(),
            CA = CertificateAuthority
        };
    }

  
}