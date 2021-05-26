using ElectMe_WebClient.ECIES.Common.ECC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectMe_WebClient.ECIES.util;

namespace ElectMe_WebClient.Models
{
    public class NIOSPackage
    {
        public EllipticCurvePoint clientPUk { get; set; } 
        public ECIESProcessResult encryptedCredentials { get; set;}
    }
}
