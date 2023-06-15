using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HandyMan_Techlift.Areas.Identity.Data;
using HandyMan_Techlift.Data;
using HandyMan_Techlift.Repositories;
//using HandyMan_Techlift.Configuration;

//using HandyMan_Techlift.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HandyManDbContextConnection");

builder.Services.AddDbContext<HandyManDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HandyManDbContext>();
//builder.Services.AddDefaultIdentity<HandyMan_TechliftUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HandyManDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoriesrep, Categoriesrep>();
builder.Services.AddScoped<IServicesrep, Servicesrep>();

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
