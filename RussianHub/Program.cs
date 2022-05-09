using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VideoContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("VIdeoContext") ?? throw new InvalidOperationException("Connection string 'VIdeoContext' not found.")));
var config = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection =
        config.GetSection("Authentication:Google");
        options.ClientId = "300502537276-j7vrh5m39t5ni9a948m7qrvc8m4pk6vu.apps.googleusercontent.com";
        options.ClientSecret = "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";
    })
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = "88e303fd-6e9d-4029-8b3b-ec15ef6301c7";
        microsoftOptions.ClientSecret = "e973778c-c920-4fb4-ba16-2a81c988c60b";
    }); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
