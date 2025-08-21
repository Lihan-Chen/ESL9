using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Tokens;

namespace Prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
                //.AddOpenIdConnect(options =>
                //{
                //    // ... your other options ...
                //    options.Events = new OpenIdConnectEvents
                //    {
                //        OnTokenValidated = async context =>
                //        {
                //            var principal = context.Principal;
                //            var userName = principal.FindFirst("preferred_username")?.Value; // or whatever claim is available

                //            // Fetch user ID from your database/service
                //            var userId = await GetUserIdFromDatabaseAsync(userName); // implement this method

                //            if (!string.IsNullOrEmpty(userId))
                //            {
                //                var identity = (ClaimsIdentity)principal.Identity!;
                //                identity.AddClaim(new Claim("userid", userId));
                //            }
                //        }
                //    };
                //});
            //.EnableTokenAcquisitionToCallDownstreamApi()
            //.AddInMemoryTokenCaches();

            // to map the claims from the OpenID Connect token to the application claims
            builder.Services.Configure<MicrosoftIdentityOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters.NameClaimType = "userid";
                options.TokenValidationParameters.RoleClaimType = "role";
            });

            //builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformation>();

            //builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            builder.Services.AddRazorPages()
                .AddMicrosoftIdentityUI();

            // to support AddSession below in a single server setup
            builder.Services.AddDistributedMemoryCache(); // Or another IDistributedCache implementation

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(180); // Set session timeout
                options.Cookie.Name = ".ESL.Session"; // Make unique Cookie name to avoid "Error unprotecting the session cookie"
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapAreaControllerRoute(
                name: "Public", // A unique name for your area route
                areaName: "Public", // The exact name of your area folder
                pattern: "Public/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapAreaControllerRoute(
                name: "Admin", // A unique name for your area route
                areaName: "Admin", // The exact name of your area folder
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
