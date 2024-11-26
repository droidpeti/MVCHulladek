﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHulladek.Models
{
    public class Lakig
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Igeny { get; set; }
        [ForeignKey("SzolgaltatasId")]
        public int SzolgaltatasId { get; set; }
        public Szolgaltatas? Szolgaltatas { get; set; }
        [Required]
        public int Mennyiseg {  get; set; }
    }
}
