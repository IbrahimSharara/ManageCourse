using ManageCourses.Models;
using ManageCourses.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add DbContext
builder.Services.AddDbContext<ManageCourseContext>(op =>
{
    op.UseSqlServer("Data Source=.;Initial Catalog=ManageCourse;Integrated Security=True");
});
// Add Repositorys
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAdminRepository , AdminRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//app.MapAreaControllerRoute(
//    name: "area",
//    areaName: "admin",
//    pattern: "{area:exists}/{controller=Account}/{action=login}/{id?}");

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Account}/{action=login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
