using ElectMe_WebServer.ECIES.Common.ECC;
using ElectMe_WebServer.ECIES.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectMe_WebServer.Models
{
    public class NIOSPackage
    {
        public EllipticCurvePoint clientPUk { get; set; }
        public ECIESProcessResult encryptedCredentials { get; set; }
    }
}
