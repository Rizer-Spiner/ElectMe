using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteServer.Models
{
    public class VoteToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Token { get; set; }

        [Display(Name = "Has voted")] public bool HasVote { get; set; }
    }
}