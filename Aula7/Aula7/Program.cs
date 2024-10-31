using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Aula7.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Aula7Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Aula7Context") ?? throw new InvalidOperationException("Connection string 'Aula7Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt=>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(10);
    opt.Cookie.Name = ".Aula07_PL2";
});
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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
