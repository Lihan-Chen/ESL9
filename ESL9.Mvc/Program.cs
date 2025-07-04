using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using ESL9.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ESL9.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContextPool<EslDbContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("EslDbContext"), b =>
                                                    b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23)), poolSize: 1024);

        // Register the new DbContext for views
        //builder.Services.AddDbContextPool<EslViewContext>(options =>
        //    options.UseOracle(
        //        builder.Configuration.GetConnectionString("EslDbContext"),
        //        b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23)
        //    ),
        //    poolSize: 1024
        //);
        //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        //// Register with interfaces in Program.cs
        //builder.Services.AddScoped<IEslDbContext>(provider => provider.GetService<EslDbContext>());
        //builder.Services.AddScoped<IEslViewContext>(provider => provider.GetService<EslViewContext>());


        // Register repositories
        //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //builder.Services.AddScoped<IEventViewRepository, EventViewRepository>();

        // Add services to the container.
        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

        builder.Services.AddControllersWithViews(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });
        builder.Services.AddRazorPages()
            .AddMicrosoftIdentityUI();

        // 1. Register session services
        builder.Services.AddSession(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true; // Required for GDPR compliance
                                               // You can set other options like IdleTimeout if needed
                                               // options.IdleTimeout = TimeSpan.FromMinutes(30);
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
        app.UseRouting();

        // 2. Add the session middleware before UseAuthorization
        app.UseSession();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
