using BazaDanych.Data.CMS.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BazaDanych.Data.CMS.Wypozyczenia;

namespace BazaDanych.Data.CMS.Uzytkownicy
{
    public class Uzytkownik : ACommonProperties
    {
        [Required(ErrorMessage = "Imie jest wymagane")]
        [MaxLength(200, ErrorMessage = "Imie może mieć maksymalnie 200 znaków")]
        [Display(Name = "Nazwa użytkownika")]
        public required string Imie { get; set; }
        [Display(Name = "Nazwisko użytkownika")]
        [MaxLength(200, ErrorMessage = "Nazwisko może mieć maksymalnie 200 znaków")]
        public string? Nazwisko { get; set; }
        [Required(ErrorMessage = "E-mail jest wymagany")]
        [MaxLength(200, ErrorMessage = "E-mail może mieć maksymalnie 200 znaków")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MaxLength(200, ErrorMessage = "Hasło może mieć maksymalnie 200 znaków")]
        [Display(Name = "Hasło")]
        public required string Password { get; set; }
        [MaxLength(30, ErrorMessage = "Telefon kontaktowy może mieć maksymalnie 30 znaków")]
        [Display(Name = "Telefon kontaktowy")]
        public string? TelefonKontaktowy { get; set; }
        [MaxLength(200, ErrorMessage = "Adres zamieszkania może mieć maksymalnie 200 znaków")]
        [Display(Name = "Adres zamieszkania")]
        public string? ZamieszkanieAdres { get; set; }
        [MaxLength(200, ErrorMessage = "Miasto może mieć maksymalnie 200 znaków")]
        [Display(Name = "Miasto")]
        public string? ZamieszkanieMiasto { get; set; }
        [MaxLength(30, ErrorMessage = "Kod pocztowy może mieć maksymalnie 30 znaków")]
        [Display(Name = "Kod poczotwy")]
        public string? ZamieszkanieKodPoczotwy { get; set; }
        [MaxLength(200, ErrorMessage = "Adres korespondencyjny może mieć maksymalnie 200 znaków")]
        [Display(Name = "Adres korespondencyjny")]
        public string? KorespondencyjnyAdres { get; set; }
        [MaxLength(200, ErrorMessage = "Miasto do korespondencji może mieć maksymalnie 200 znaków")]
        [Display(Name = "Miasto do korespondencji")]
        public string? KorespondencyjnyMiasto { get; set; }
        [MaxLength(30, ErrorMessage = "Kod pocztowy do korespondencji może mieć maksymalnie 30 znaków")]
        [Display(Name = "Kod pocztowy do korespondencji")]
        public string? KoresponedncyjnyKodPocztowy { get; set; }
        [MaxLength(200, ErrorMessage = "Nazwa firmy może mieć maksymalnie 200 znaków")]
        [Display(Name = "Nazwa firmy")]
        public string? FirmaNazwa { get; set; }
        [MaxLength(18, ErrorMessage = "Nip firmy może mieć maksymalnie 18 znaków")]
        [Display(Name = "Nip firmy")]
        public string? FirmaNip { get; set; }
        [MaxLength(200, ErrorMessage = "Adres firmy może mieć maksymalnie 200 znaków")]
        [Display(Name = "Adres firmy")]
        public string? FirmaAdres { get; set; }
        [MaxLength(200, ErrorMessage = "Miasto firmy może mieć maksymalnie 200 znaków")]
        [Display(Name = "Miasto firmy")]
        public string? FirmaMiasto { get; set; }
        [MaxLength(30, ErrorMessage = "Kod pocztow firmy może mieć maksymalnie 30 znaków")]
        [Display(Name = "Kod pocztowy")]
        public string? FirmaKodPocztowy { get; set; }

        [ForeignKey("SlTypUzytkownika")]
        [Display(Name = "Uprawnienia uzytkownika")]
        public int IdSlTypUzytkownika { get; set; }
        [Display(Name = "Uprawnienia uzytkownika")]
        public SlTypUzytkownika? SlTypUzytkownika { get; set; }

        public ICollection<RejestrWypozyczen> RejestrWypozyczens { get; } = [];
    }
}
