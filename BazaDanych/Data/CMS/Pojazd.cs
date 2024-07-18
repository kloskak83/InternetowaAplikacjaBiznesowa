using BazaDanych.Data.CMS.Wypozyczenia;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaDanych.Data.CMS;

    public class Pojazd
{
	[Key]
	public int IdPojazd { get; set; }

	public bool IsDeleted { get; set; } = false;

	[ForeignKey("SlMarka")]
	[Display(Name = "Marka pojazdu")]
	public int IdSlownikMarka { get; set; }
	[Display(Name = "Marka pojazdu")]
	public SlMarka? SlMarka { get; set; }

	[Required(ErrorMessage = "Model pojazdu jest wymagana")]
	[MaxLength(100, ErrorMessage = "Model pojazdu może mieć maksymalnie 100 znaków")]
	[Display(Name = "Model pojazdu")]
	public required string Model { get; set; }

	[Required(ErrorMessage = "Nazwa jest wymagana")]
	[MaxLength(100, ErrorMessage = "Nazwa może mieć maksymalnie 100 znaków")]
	[Display(Name = "Nazwa marketingowa w serwisie")]
	public required string NazwaWSerwisie { get; set; }

	[ForeignKey("SlTypSilnika")]
	[Display(Name = "Typ silnika")]
	public int IdTypSilnika { get; set; }
	[Display(Name = "Typ silnika")]
	public SlTypSilnika? SlTypSilnika { get; set; }

	[ForeignKey("SlTypSkrzyniBiegow")]
	[Display(Name = "Skrzynia biegów")]
	public int IdTypSkrzyniBiegow { get; set; }
	[Display(Name = "Skrzynia biegów")]
	public SlTypSkrzyniBiegow? SlTypSkrzyniBiegow { get; set; }

	[ForeignKey("SlSegmentPojazdu")]
	[Display(Name = "Segment")]
	public int IdSegmentPojazdu { get; set; }
	[Display(Name = "Segment")]
	public SlSegmentPojazdu? SlSegmentPojazdu { get; set; }

	//Poprawic na wiele do wielu
	//IdCechaPojazdu
	public List<SlCechaPojazdu> SlCechaPojazdus { get; } = [];

	public List<RejestrWypozyczen> RejestrWypozyczens { get; } = [];


	[Display(Name = "Klimatyzacja")]
	public bool CzyMaKlimatyzacje { get; set; }
	[Display(Name = "Pojemność silnika")]
	public float PojemnoscSilnika { get; set; }
	[Display(Name = "Moc silnika")]
	public float MocSilnika { get; set; }
	[Display(Name = "Spalanie miejskie")]
	public float SpalanieMiejskie {  get; set; }
	[Display(Name = "Ilość poduszek")]
	public int IloscPoduszek {  get; set; }
	[Display(Name = "Ilość drzwi")]
	public int IloscDrzwi {  get; set; }
	[Display(Name = "ABS")]
	public bool CzyMaABS {  get; set; }
	[Display(Name = "Elekryczne szyby")]
	public bool CzyMaElektryczneSzyby { get; set; }
	[Display(Name = "Elektryczne lusterka")]
	public bool CzyMaElektryczneLusterka { get; set; }
	[Display(Name = "Podgrzewane lusterka")]
	public bool CzyMaPodgrzewaneLusterka { get; set; }
	[Display(Name = "Komputer pokładowy")]
	public bool CzyMaKomputerPokladowy {  get; set; }
	[Display(Name = "Centralny zamek")]
	public bool CzyMaCentralnyZamek {  get; set; }
	[Display(Name = "Data produkcji")]
	public DateOnly DataProdukcji { get; set; }
	[Display(Name = "Opis pojazdu")]
	public string? OpisPojazdu { get; set; }

        [Display(Name = "Zdjęcie")]
        [NotMapped]
        [Required]
	public IFormFile Zdjecie {  get; set; }
        
        public string SciezkaDoZdjecia { get; set; }


        [Display(Name = "Koszt wypożyczenia")]
        public decimal KosztWypozyczeniaDoba { get; set; }
       

    }
