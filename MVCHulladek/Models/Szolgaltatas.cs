using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHulladek.Models
{
    public class Szolgaltatas
    {
        [Required]
        public int SzolgaltatasId { get; set; }
        [Required]
        public string Tipus { get; set; }
        [Required]
        public string Jelentes { get; set; }
    }
}
