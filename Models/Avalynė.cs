using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Avalynė : IValidatableObject
    {
        public Avalynė()
        {
            Naudojas = new HashSet<Naudoja>();
        }

        [Required]
        [Range(1, 99, ErrorMessage = "Length must be between 1-2 digits.")]
        public int Dydis { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public double Kaina { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Length must be between 1-15 characters.")]
        public string Spalva { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int PartijosNumeris { get; set; }
        [Required]
        public DateTime PagaminimoData { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int IndividualusNumeris { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkModelisidModelis { get; set; }

        public virtual Modeli FkModelisidModelisNavigation { get; set; }
        public virtual ICollection<Naudoja> Naudojas { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PagaminimoData > DateTime.Now)
            {
                yield return new ValidationResult("Pagaminimo data negali būti ateityje.", new[] { nameof(PagaminimoData) });
            }

        }
    }
}
