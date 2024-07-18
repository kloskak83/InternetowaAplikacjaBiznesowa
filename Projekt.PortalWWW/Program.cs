using BazaDanych.Data;
using BazaDanych.Data.CMS;
using BazaDanych.Data.Portal;
using Projekt.Interfaces.Data.CMS;
using Projekt.Interfaces.Data.Menu;
using Projekt.Interfaces.Data.Portal;
using Projekt.Services.Data.CMS;
using Projekt.Services.Data.Menu;
using Projekt.Services.Data.Portal;

namespace Projekt.PortalWWW;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BazaContext>();
        builder.Services.AddScoped<IAktualnoscService<Aktualnosc>, AktualnoscService>();
        builder.Services.AddScoped<IPojazdService<Pojazd>, PojazdService>();
        builder.Services.AddScoped<IStronaService<Strona>,StronaService>();
        builder.Services.AddScoped<IStronyNaSztywnoService, StronaNaSztywnoService>();
        builder.Services.AddScoped<IStronyNaSztywnoService, StronaNaSztywnoService>();
        builder.Services.AddScoped<IMenuGorneService, MenuGorneServices>();
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
