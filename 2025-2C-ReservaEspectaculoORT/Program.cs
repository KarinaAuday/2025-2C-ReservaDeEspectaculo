using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuro la Base de Datos
//builder.Services.AddDbContext<ReservaEspectaculoContext>(options =>
//options.UseInMemoryDatabase("ReservaEspectaculoDB"));

//Configuro SQL Server
////Agrego la base de datos SQL , y guardo el conection string en el appsetting.json
builder.Services.AddDbContext<ReservaEspectaculoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReservaEspectaculoDBCS")));
builder.Services.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<ReservaEspectaculoContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
