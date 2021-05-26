using ElectMe_WebServer.ECIES.Common.ECC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectMe_WebServer.ECIES.util;

namespace ElectMe_WebServer.Models
{
    public class LoginContainer
    {
        // public string encryptedLoginPackage { get; set; }
        // public EllipticCurvePoint clientPuk { get; set; }
        // public byte[] tag { get; set; }
        
        public EllipticCurvePoint clientPuk { get; set; }
        public ECIESProcessResult loginPackage { get; set; }
    }
}
