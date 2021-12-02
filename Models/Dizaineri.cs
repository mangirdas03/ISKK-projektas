using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Dizaineri : IValidatableObject
    {
        public Dizaineri()
        {
            Modelis = new HashSet<Modeli>();
            Samdos = new HashSet<Samdo>();
        }

        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Vardas { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Pavardė { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int AsmensKodas { get; set; }
        [Required]
        public DateTime GimimoData { get; set; }

        public virtual ICollection<Modeli> Modelis { get; set; }
        public virtual ICollection<Samdo> Samdos { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GimimoData > DateTime.Now)
            {
                yield return new ValidationResult("Įkūrimo data negali būti ateityje.", new[] { nameof(GimimoData) });
            }

        }

    }
}
