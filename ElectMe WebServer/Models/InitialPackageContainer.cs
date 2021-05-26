using ElectMe_WebServer.ECIES;
using ElectMe_WebServer.ECIES.ECDSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectMe_WebServer.Models
{
    public class InitialPackageContainer
    {
        public InitialPackage initialPackage { get; set; }
        public Signature signature { get; set; }
    }
}
