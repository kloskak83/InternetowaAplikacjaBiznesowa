using BazaDanych.Data.CMS.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Data.CMS
{
	public class SlSegmentPojazdu : ACommonProperties
	{
		[Required(ErrorMessage = "Nazwa segmentu pojazdu jest wymagana")]
		[MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
		[Display(Name = "Nazwa segmentu pojazdu")]
		public required string NazwaSegmentuPojazdu { get; set; }
		public ICollection<Pojazd> Pojazdy { get; } = new List<Pojazd>();
	}
}
