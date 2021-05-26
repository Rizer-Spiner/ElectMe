using ElectMe_WebServer.ECIES.Common.ECC;
using System.ComponentModel.DataAnnotations;

namespace ElectMe_WebServer.Models
{
    public class LoginPackage
    {
        [Required]
        [StringLength(10, ErrorMessage = "Cpr number is a 10 digits number", MinimumLength = 10)]
        public string Cpr { get; set; }
        public NIOSPackage niosPackage { get; set; }

    }
}