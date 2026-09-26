using EmailDiario.Data;
using Microsoft.EntityFrameworkCore;
using EmailDiario.DAO;
using EmailDiario.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString =
    builder.Configuration.GetConnectionString("EmailDiario")
    ?? throw new InvalidOperationException(
        "A conexão EmailDiario não foi configurada.");

builder.Services.AddDbContext<EmailDiarioDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<DestinatarioDAO>();
builder.Services.AddScoped<DestinatarioService>();

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
