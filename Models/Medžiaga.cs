using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Medžiaga
    {
        public Medžiaga()
        {
            Naudojas = new HashSet<Naudoja>();
        }

        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Pavadinimas { get; set; }
        
        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Tipas { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Apdirbimas { get; set; }
        
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int IdMedžiaga { get; set; }

        public virtual ICollection<Naudoja> Naudojas { get; set; }
    }
}
