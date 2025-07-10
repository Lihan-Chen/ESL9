using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore.Infrastructure;

namespace ESL9.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Fix for CS1061: Ensure the required package is installed and the namespace is included
        // AddDbContextPool is part of Microsoft.EntityFrameworkCore package
        builder.Services.AddDbContextPool<EslDbContext>(options =>
            options.UseOracle(
                builder.Configuration.GetConnectionString("EslDbContext"),
                b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23
            )),
            poolSize: 1024
        );

        builder.Services.AddDbContextPool<EslViewContext>(options =>
            options.UseOracle(
                builder.Configuration.GetConnectionString("EslDbContext"),
                b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23
            )),
            poolSize: 1024
        );

        // Remaining code unchanged
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

        builder.Services.AddSession(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
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
