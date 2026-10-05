using IsllihaiProjectBL.Services.Classes;
using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Reposatories.Classes;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DEPENDANCY INJECTION
builder.Services.AddDbContext<IslahiniDbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
);
//builder.Services.AddScoped(typeof (IGenericRepo<>), typeof (GenericRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITecnicianRepo , TecnicianRepo>();
builder.Services.AddScoped<IBookingRepo , BookingRepo>();
builder.Services.AddScoped<ICategoreyRepo , CategoreyRepo>();
builder.Services.AddScoped<IReviewRepo  , ReviewRepo>();

builder.Services.AddScoped<ICategoryService, CategoryServcie>();
builder.Services.AddScoped<ITechnicainService, TechnicainService>();
builder.Services.AddScoped<IBookingServices, BookingService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ILoginService, LoginService>();
//
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<IslahiniDbContext>();
builder.Services.ConfigureApplicationCookie(opt => 
{
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.LoginPath = "/Account/Login";
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
