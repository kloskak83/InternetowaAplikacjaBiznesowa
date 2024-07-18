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
    public class Strona : ACommonProperties
    {
        [Required(ErrorMessage = "Wpisz tytuł odnośnika do strony")]
        [MaxLength(50, ErrorMessage = "Tytuł powinien zawierać max 50 znaków")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł strony")]
        [MaxLength(200, ErrorMessage = "Tytuł strony powinien zawierać max 200 znaków")]
        [Display(Name = "Tytuł Strony")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Wpisz treść strony")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        [ForeignKey("SlRodzajeStron")]
        [Display(Name = "Rodzaje stron")]
        public int IdSlRodzajeStron { get; set; }
        [Display(Name = "Rodzaje stron")]
        public SlRodzajeStron? SlRodzajeStron { get; set; }


    }
}
