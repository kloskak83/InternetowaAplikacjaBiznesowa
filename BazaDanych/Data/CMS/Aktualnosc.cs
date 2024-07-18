using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaDanych.Data.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int AktualnosciId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Display(Name = "Data publikacji")]
        public DateOnly DataAktualnosci { get; set; }

        [Required(ErrorMessage = "Nagłówek jest wymagany")]
        [MaxLength(400, ErrorMessage = "Nagłówek może mieć maksymalnie 400 znaków")]
        [Display(Name = "Nagłówek")]
        public required string Naglowek { get; set; }

        [Required(ErrorMessage = "Musisz podać treść artykułu")]
        [Display(Name = "Treść artykułu")]
        public required string Opis { get; set; }
       
        [Display(Name = "Zdjęcie")]
        [NotMapped]
        [Required]
        public IFormFile Zdjecie { get; set; }

        public string SciezkaDoZdjecia { get; set; }

    }
}
