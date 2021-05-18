using System.Numerics;
using System.Text;
using ElectMe_WebServer.ECIES.KeyGeneration;

namespace ElectMe_WebServer.ECIES
{
    public class EncryptionVariables
    {
        public static readonly EllipticCurve EllipticCurveForClient = new()
        {
            a = 4,
            b = 3,
            G = new EllipticCurvePoint {x = 234, y = 121},
            n = 180181,
            h = 0,
            p = 0
        };

        public static readonly BigInteger PrkcForClient = PrivateKeyGenerator.generatePrivateKey();

        public static readonly EllipticCurvePoint PukForClients = KeyGeneration.KeyGeneration.calculatePublicKey(
            PrkcForClient,
            EllipticCurveForClient.G, EllipticCurveForClient);

        public static readonly InitialPackage certificate = new()
        {
            EllipticCurve = EllipticCurveForClient,
            ServerPuk = PukForClients,
            CertificateSignature = Encoding.ASCII.GetBytes("Certificate Authority signature"),
            NiosKey = Encoding.ASCII.GetBytes("NIOS encryption/decryption Key")
        };

        // public static readonly byte[] NIOSKey = Encoding.ASCII.GetBytes("NIOS encryption/decryption Key");
    }

  
}