using ElectMe_WebServer.ECIES.Common.ECC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectMe_WebServer.Models
{
    public class LoginContainer
    {
        public string encryptedLoginPackage { get; set; }
        public EllipticCurvePoint clientPuk { get; set; }
        public byte[] tag { get; set; }
    }
}
