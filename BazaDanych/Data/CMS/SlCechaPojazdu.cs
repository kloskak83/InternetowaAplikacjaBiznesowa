using BazaDanych.Data.CMS.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.CMS;

//Wiele do wielu
public class SlCechaPojazdu : ACommonProperties
{
	[Required(ErrorMessage = "Cecha pojazdu jest wymagana")]
	[MaxLength(50, ErrorMessage = "Cecha może mieć maksymalnie 50 znaków")]
	[Display(Name = "Nazwa cechy pojazdu")]
	public required string CechaPojazdu { get; set; }
	public List<Pojazd> Pojazds { get; } = [];
}
