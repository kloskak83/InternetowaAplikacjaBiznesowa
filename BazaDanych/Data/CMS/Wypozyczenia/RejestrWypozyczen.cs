using BazaDanych.Data.CMS.Abstractions;
using BazaDanych.Data.CMS.Uzytkownicy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaDanych.Data.CMS.Wypozyczenia;

public class RejestrWypozyczen : ACommonProperties
{
    [ForeignKey("Pojazd")]
    [Display(Name = "Wypozyczony pojazd")]
    public int IdPojazd { get; set; }
    [Display(Name = "Wypozyczony pojazd")]
    public required Pojazd Pojazd { get; set; }


    [ForeignKey("NazwaStatusuWypozyczenia")]
    [Display(Name = "Stan wypozyczenia")]
    public int IdNazwaStatusuWypozyczenia { get; set; }
    [Display(Name = "Stan wypozyczenia")]
    public required NazwaStatusuWypozyczenia NazwaStatusuWypozyczenia { get; set; }

    [ForeignKey("Uzytkownik")]
    [Display(Name = "Id uzykownika")]
    public int IdUzytkownik { get; set; }
    [Display(Name = "Nazwa uzytkownika")]
    public required Uzytkownik Uzytkownik { get; set; }

    public required DateTime WypozyczenieOd {  get; set; }
    public required DateTime WypozyczenieDo { get; set; }

}
