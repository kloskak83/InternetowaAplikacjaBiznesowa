using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.CMS;

public class SlMarka
{
	[Key]
	public int IdSlMarka { get; set; }
	public bool IsDeleted { get; set; } = false;
	[Required(ErrorMessage = "Marka pojazdu jest wymagana")]
	[MaxLength(100, ErrorMessage = "Marka może mieć maksymalnie 100 znaków")]
	[Display(Name = "Marka pojazdu")]
	public required string MarkaPojazdu { get; set; }
	public ICollection<Pojazd> Pojazdy { get; } = new List<Pojazd>();
}
