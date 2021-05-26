using ElectMe_WebClient.ECIES;
using ElectMe_WebClient.ECIES.ECDSA;


namespace ElectMe_WebClient.Models
{
    public class InitialPackageContainer
    {
        public InitialPackage initialPackage { get; set; }
        public Signature signature { get; set; }
    }
}
