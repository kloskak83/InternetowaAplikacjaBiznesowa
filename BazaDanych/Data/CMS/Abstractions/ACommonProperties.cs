using System.ComponentModel.DataAnnotations;

namespace BazaDanych.Data.CMS.Abstractions
{
    public abstract class ACommonProperties
    {
        [Key]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
