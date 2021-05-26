using ElectMe_WebClient.ECIES;
using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.ECDSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectMe_WebClient.Models
{
    public class InitialPackageContainer
    {
        public InitialPackage initialPackage { get; set; }
        public Signature signature { get; set; }
    }
}
