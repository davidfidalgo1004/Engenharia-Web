using Class06.Data;
using Humanizer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Class06Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Class06Context"))
);

builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DbInitializer>();
initializer.Run();

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


//app.MapControllerRoute(
//    name: "filtered",
//    pattern: "Filter/{letter?}",
//    defaults: new { Controller = "students", Action = "Index2" }
//    constraints: new { letter = new MyRulesContrains() }
//    );

//app.MapControllerRoute(
//    name: "filtered",
//    pattern: "Filter/{letter:alpha:length(1)?}",
//    defaults: new { Controller = "students", Action = "Index2" }
//    );

//app.MapControllerRoute(
//    name: "filtered",
//    pattern: "Filter/{letter?}",
//    defaults: new { Controller = "students", Action = "Index2" },
//    constraints: new { letter = @"[A-Z¡”…Õ⁄]" }
//    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
