using BazaDanych.Data;
using BazaDanych.Data.CMS;
using BazaDanych.Data.CMS.Uzytkownicy;
using BazaDanych.Data.Portal;
using Projekt.Interfaces.Data.CMS;
using Projekt.Interfaces.Data.CMS.Uzytkownicy;
using Projekt.Interfaces.Data.Menu;
using Projekt.Interfaces.Data.Portal;
using Projekt.Intranet.Helpers;
using Projekt.Intranet.Helpers.IHelpers;
using Projekt.Services.Data.CMS;
using Projekt.Services.Data.CMS.Uzytkownicy;
using Projekt.Services.Data.Menu;
using Projekt.Services.Data.Portal;

namespace Projekt.Intranet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BazaContext>();
        //TODO: (AK: Rejestrowanie) Czy to jest to samo co na zajeciach, czy jest roznica o ktorej nie wiem?
        builder.Services.AddScoped<ISlMarkaService<SlMarka>, SlMarkaService>();
        builder.Services.AddScoped<ISlCechaPojazduService<SlCechaPojazdu>, SlCechaPojazduService>();
        builder.Services.AddScoped<ISlSegmentPojazduService<SlSegmentPojazdu>, SlSegmentPojazduService>();
        builder.Services.AddScoped<ISlTypSilnikaService<SlTypSilnika>, SlTypSilnikaService>();
        builder.Services.AddScoped<ISlTypSkrzyniBiegowService<SlTypSkrzyniBiegow>, SlTypSkrzyniBiegowService>();
        builder.Services.AddScoped<IAktualnoscService<Aktualnosc>, AktualnoscService>();
        builder.Services.AddScoped<IPojazdService<Pojazd>, PojazdService>();
        builder.Services.AddScoped<ISlTypUzytkownikaService<SlTypUzytkownika>, SlTypUzytkownikaService>();
        builder.Services.AddScoped<IUzytkownikService<Uzytkownik>, UzytkownikService>();
        builder.Services.AddScoped<IStronaService<Strona>, StronaService>();
        builder.Services.AddScoped<ISlRodzajeStronService<SlRodzajeStron>,SlRodzajeStronService>();
        builder.Services.AddScoped<IStronyNaSztywnoService, StronaNaSztywnoService>();
        builder.Services.AddScoped<IMenuGorneService, MenuGorneServices>();
        
        builder.Services.AddTransient<IFileHelper,FileHelper>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
