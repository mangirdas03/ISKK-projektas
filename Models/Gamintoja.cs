using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Gamintoja : IValidatableObject
    {
        public Gamintoja()
        {
            Modelis = new HashSet<Modeli>();
            Samdos = new HashSet<Samdo>();
        }

        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Pavadinimas { get; set; }
        [Required]
        public DateTime ĮkūrimoData { get; set; }
        [Required]
        //[Range(0, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int MetinisPelnas { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int IdGamintojas { get; set; }

        public virtual ICollection<Modeli> Modelis { get; set; }
        public virtual ICollection<Samdo> Samdos { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(MetinisPelnas < 0)
            {
                yield return new ValidationResult("Metinis pelnas negali būti neigiamas.", new[] { nameof(MetinisPelnas) });
            }
            if(ĮkūrimoData > DateTime.Now)
            {
                yield return new ValidationResult("Įkūrimo data negali būti ateityje.", new[] { nameof(ĮkūrimoData) });
            }

        }



    }
}
