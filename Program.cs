using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Toolbelt.Blazor.SpeechSynthesis;
using Weather2EB.Data;

namespace Weather2EB
{
 public class Program
 {
  public static void Main(string[] args)
  {
   var builder = WebApplication.CreateBuilder(args);

   // Add services to the container.
   builder.Services.AddSpeechSynthesis();
   builder.Services.AddScoped<HttpClient, HttpClient>();
   builder.Services.AddRazorPages();
   builder.Services.AddServerSideBlazor();
   builder.Services.AddScoped<WeatherForecastService>();
   builder.Services.AddScoped<ZipService>();

   var app = builder.Build();

   // Configure the HTTP request pipeline.
   if (!app.Environment.IsDevelopment())
   {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   }

   app.MapControllers();

   app.UseHttpsRedirection();

   app.UseStaticFiles();

   app.UseRouting();

   app.MapBlazorHub();
   app.MapFallbackToPage("/_Host");

   app.Run();
  }
 }
}
