using BazaDanych.Data.CMS;
using BazaDanych.Data.CMS.Uzytkownicy;
using BazaDanych.Data.CMS.Wypozyczenia;
using BazaDanych.Data.Menu;
using BazaDanych.Data.Portal;
using Microsoft.EntityFrameworkCore;

namespace BazaDanych.Data;

public class BazaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"
        Server=(localdb)\mssqllocaldb;Database=ProjektTest;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
    public DbSet<Aktualnosc> Aktualnosci { get; set; }
    public DbSet<Pojazd> Pojazdy { get; set; }
    public DbSet<SlCechaPojazdu> SlCechyPojazdow { get; set; }
    public DbSet<SlMarka> SlMarkiPojazdow { get; set; }
    public DbSet<SlSegmentPojazdu> SlSegmentyPojazdow { get; set; }
    public DbSet<SlTypSilnika> SlTypySilnikow { get; set; }
    public DbSet<SlTypSkrzyniBiegow> SlTypySkrzyniBiegow { get; set; }
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<SlTypUzytkownika> SlTypUzytkownik { get; set; }
    public DbSet<Strona> Strony { get; set; }
    public DbSet<SlRodzajeStron> RodzejStron { get; set; }
    public DbSet<StronaNaSztywno> StronyNaSztywno { get; set; }
    public DbSet<RejestrWypozyczen> RejestrWypozyczens { get; set; }
    public DbSet<NazwaStatusuWypozyczenia> StatusWypozyczenia { get; set; }
    public DbSet<MenuGorne> MenuGornes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<PojazdSlCechaPojazdu>()
        //	.HasKey(ba => new { ba.PojazdyId, ba.SlCechyPojazdowId });

        //modelBuilder.Entity<PojazdSlCechaPojazdu>()
        //	.HasOne(ba => ba.Pojazd)
        //	.WithMany(b => b.PojazdySlCechyPojazdow)
        //	.HasForeignKey(ba => ba.PojazdyId);

        //modelBuilder.Entity<PojazdSlCechaPojazdu>()
        //	.HasOne(ba => ba.SlCechaPojazdu)
        //	.WithMany(a => a.PojazdySlCechyPojazdow)
        //	.HasForeignKey(ba => ba.SlCechyPojazdowId); 

        //Ponizsza relacja powinna byc ok
        modelBuilder.Entity<Pojazd>()
            .HasMany(e => e.SlCechaPojazdus)
            .WithMany(e => e.Pojazds)
            .UsingEntity<PojazdSlCechaPojazdu>();

        modelBuilder.Entity<Pojazd>()
            .Property(e => e.KosztWypozyczeniaDoba)
            .HasColumnType("decimal(18, 2)");
    }

}
