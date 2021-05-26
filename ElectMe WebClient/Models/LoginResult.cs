using System.Collections.Generic;
using ElectMe_WebClient.ECIES.Common.ECC;

namespace ElectMe_WebClient.Models
{
    public class LoginResult
    {
        public int Status { get; set; }
        public string AuthToken { get; set; }
        public EllipticCurvePoint ElectionPuk;
        public List<string> Choices { get; set; }
    }
}