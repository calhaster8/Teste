using Microsoft.EntityFrameworkCore;
using Teste.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDb")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var salesContext = scope.ServiceProvider.GetRequiredService<SalesContext>();
    salesContext.Database.EnsureCreated();
    salesContext.Seed();
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

