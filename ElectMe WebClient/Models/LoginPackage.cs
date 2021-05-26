using ElectMe_WebClient.ECIES.Common.ECC;
using ElectMe_WebClient.ECIES.KeyGeneration;
using ElectMe_WebClient.Models;
using System.ComponentModel.DataAnnotations;

namespace ElectMe_WebClient.Models
{
    public class LoginPackage
    {
        [Required]
        [StringLength(10, ErrorMessage = "Cpr number is a 10 digits number", MinimumLength = 10)]
        public string Cpr { get; set; } //why hashed?
        public NIOSPackage niosPackage { get; set; }
    }
}