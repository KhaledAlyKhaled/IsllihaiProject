using IsllihaiProjectBL.Services.Classes;
using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Reposatories.Classes;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DEPENDANCY INJECTION
builder.Services.AddDbContext<islahiniDbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
);
//builder.Services.AddScoped(typeof (IGenericRepo<>), typeof (GenericRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITecnicianRepo , TecnicianRepo>();
builder.Services.AddScoped<IBookingRepo , BookingRepo>();
builder.Services.AddScoped<ICategoreyRepo , CategoreyRepo>();

builder.Services.AddScoped<ICategoryService, CategoryServcie>();
builder.Services.AddScoped<ITechnicainService, TechnicainService>();
builder.Services.AddScoped<IBookingServices, BookingService>();
//
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
