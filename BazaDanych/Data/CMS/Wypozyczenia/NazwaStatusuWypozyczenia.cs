using BazaDanych.Data.CMS.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.CMS.Wypozyczenia;

public class NazwaStatusuWypozyczenia : ACommonProperties
{
    [Required(ErrorMessage = "Nazwa wypozyczenia jest wymagana")]
    [MaxLength(100, ErrorMessage = "Nazwa może mieć maksymalnie 100 znaków")]
    [Display(Name = "Nazwa wypożyczenie")]
    public required string NazwaWypozyczenia { get; set; }
    [MaxLength(4000, ErrorMessage = "Opis wypożyczenia może mieć maksymalnie 4000 znaków")]
    [Display(Name = "Opis pozycji")]
    public string? OpisPozycji { get; set; }
    public ICollection<RejestrWypozyczen> Pojazdy { get; } = [];
}
