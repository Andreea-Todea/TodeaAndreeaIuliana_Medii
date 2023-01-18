using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodeaAndreeaIuliana_Medii.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TodeaAndreeaIuliana_MediiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodeaAndreeaIuliana_MediiContext") ?? throw new InvalidOperationException("Connection string 'TodeaAndreeaIuliana_MediiContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
