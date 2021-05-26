using System;
using System.Collections.Generic;
using ElectMe_WebServer.ECIES.Common.ECC;

namespace ElectMe_WebServer.Models
{
    public class LoginResult
    {
        public int Status { get; set; }
        public string AuthToken { get; set; }
        public EllipticCurvePoint ElectionPuk;
        public List<string> Choices { get; set; }
    }
}