using BazaDanych.Data.CMS.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Data.CMS.Uzytkownicy
{
    public class SlTypUzytkownika : ACommonProperties
    {
        [Required(ErrorMessage ="Nazwa uprawnienia jest wymagana")]
        [MaxLength(50, ErrorMessage ="Nazwa może mieć maksymalnie 50 znaków")]
        [Display(Name = "Nazwa upranienia")]
        public required string NazwaUprawnienia { get; set; }
        [Display(Name = "Opis uprawnienia")]
        public string? OpisUprawnieniaUzytkownika { get; set; }

        public ICollection<Uzytkownik> Uzytkownicy { get; } = new List<Uzytkownik>();

    }
}
