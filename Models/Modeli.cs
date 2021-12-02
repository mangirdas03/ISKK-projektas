using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Modeli : IValidatableObject
    {
        public Modeli()
        {
            Avalynės = new HashSet<Avalynė>();
        }

        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Pavadinimas { get; set; }
        [Required]
        public DateTime SukūrimoData { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int PatentoNumeris { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int IdModelis { get; set; }
        [Required]
        [Range(1, 999999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkDizainerisasmensKodas { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkGamintojasidGamintojas { get; set; }

        public virtual Dizaineri FkDizainerisasmensKodasNavigation { get; set; }
        public virtual Gamintoja FkGamintojasidGamintojasNavigation { get; set; }
        public virtual ICollection<Avalynė> Avalynės { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SukūrimoData > DateTime.Now)
            {
                yield return new ValidationResult("Sukūrimo data negali būti ateityje.", new[] { nameof(SukūrimoData) });
            }

        }
    }
}
