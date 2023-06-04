using Microsoft.EntityFrameworkCore;
using ProjectMVCcore.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SmartphoneDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
