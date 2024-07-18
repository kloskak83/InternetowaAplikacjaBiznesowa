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
    public class StronaNaSztywno : ACommonProperties
    {
        [Required(ErrorMessage = "Wpisz tytuł odnośnika do strony")]
        [MaxLength(50, ErrorMessage = "Tytuł powinien zawierać max 50 znaków")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string LinkTytul { get; set; }
        [Required(ErrorMessage = "Wpisz treść strony")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }
    }
}
