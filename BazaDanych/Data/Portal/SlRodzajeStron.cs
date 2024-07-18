using BazaDanych.Data.CMS.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Data.Portal
{
    public class SlRodzajeStron : ACommonProperties
    {
        [Required(ErrorMessage = "Wpisz tytuł odnośnika do strony")]
        [MaxLength(10, ErrorMessage = "Tytuł powinien zawierać max 10 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        public ICollection<Strona> Strony { get; } = new List<Strona>();
    }
}
