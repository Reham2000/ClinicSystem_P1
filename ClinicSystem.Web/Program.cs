using ClinicSystem.Application.InterFaces;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Application.Mapper;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Infrastucture.Data;
using ClinicSystem.Infrastucture.Services;
using ClinicSystem.Infrastucture.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var con = builder.Configuration.GetConnectionString("con");
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(con));

builder.Services.AddIdentity<User, IdentityRole>(op =>
{
    op.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDoctorservice, DoctorService>();
builder.Services.AddScoped<IAccountService, AccountService>();



builder.Services.AddAutoMapper(config =>
{

}, typeof(DepartmentProfile).Assembly);

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
