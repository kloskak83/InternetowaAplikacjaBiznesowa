using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Data.CMS
{
	public class SlTypSkrzyniBiegow
	{
		[Key]
		public int IdSlTypSkrzyniBiegow { get; set; }
		public bool IsDeleted { get; set; } = false;

		[Required(ErrorMessage = "Nazwa typu skrzyni biegów jest wymagana")]
		[MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
		[Display(Name = "Nazwa typu skrzyni")]
		public required string NazwaTypuSkrzyniBiegow { get; set; }

		public ICollection<Pojazd> Pojazdy { get; } = new List<Pojazd>();
	}
}
