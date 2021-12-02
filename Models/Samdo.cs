using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Samdo
    {
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkDizainerisasmensKodas { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkGamintojasidGamintojas { get; set; }
        public int id { get; set; }

        public virtual Dizaineri FkDizainerisasmensKodasNavigation { get; set; }
        public virtual Gamintoja FkGamintojasidGamintojasNavigation { get; set; }
    }
}
