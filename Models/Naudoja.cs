using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace decaf.Models
{
    public partial class Naudoja
    {
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkAvalynėindividualusNumeris { get; set; }
        [Required]
        [Range(1, 9999999999, ErrorMessage = "Length must be between 1-10 digits.")]
        public int FkMedžiagaidMedžiaga { get; set; }
        public int id { get; set; }

        public virtual Avalynė FkAvalynėindividualusNumerisNavigation { get; set; }
        public virtual Medžiaga FkMedžiagaidMedžiagaNavigation { get; set; }
    }
}
