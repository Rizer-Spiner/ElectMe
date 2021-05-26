using ElectMe_WebClient.ECIES.Common.ECC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectMe_WebClient.Models
{
    public class NIOSPackage
    {
        public EllipticCurvePoint clientPUk { get; set; } 
        public string encryptedCredentials { get; set; }
        public byte[] tag { get; set; }
    }
}
