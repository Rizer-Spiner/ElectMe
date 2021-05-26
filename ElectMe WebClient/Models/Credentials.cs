using System.ComponentModel.DataAnnotations;

namespace ElectMe_WebClient.Models
{
    public class Credentials
    {
        [Required]
        [StringLength(10, ErrorMessage = "Cpr number is a 10 digits number", MinimumLength = 10)]
        public string Cpr { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Pin is a 4 digits number", MinimumLength = 4)]
        public string Pin { get; set; }
    }
}