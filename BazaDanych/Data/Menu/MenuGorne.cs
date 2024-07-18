using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.Menu;

public class MenuGorne
{
    [Key]
    public int IdMenuGorne {  get; set; }
    [Required(ErrorMessage = "Naglowek jest wymagany")]
    [MaxLength(50, ErrorMessage = "Maksymalna długość to 50 znaków")]
    [Display(Name = "Nagłówek intranet")]
    public required string NaglowekIntranet { get; set; }
    [Required(ErrorMessage = "Nazwa jest wymagana")]
    [MaxLength(50, ErrorMessage = "Maksymalna długość to 50 znaków")]
    [Display(Name = "Nazwa portal")]
    public required string NazwaPortal { get; set; }
    //TODO: Uzupelnic rodzaj pol
    public int TypPolaId { get; set; }

    public bool IsDeleted { get; set; }

}
