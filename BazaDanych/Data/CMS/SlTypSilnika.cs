using BazaDanych.Data.CMS.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.CMS;

public class SlTypSilnika : ACommonProperties
{
	[Required(ErrorMessage = "Nazwa typu silnika jest wymagana")]
	[MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
	[Display(Name = "Nazwa typu silnika")]
	public required string NazwaTypuSilnika { get; set; }

	public ICollection<Pojazd> Pojazdy { get; } = [];
}
