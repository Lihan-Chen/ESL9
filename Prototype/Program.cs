using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

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

            // with IClaimsTransformation to be persistent across requests (e.g., using claim for storing user roles)
            // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/claims?view=aspnetcore-9.0
            //builder.Services.AddAuthentication(options =>
            //{
            //    // options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //})
            //    .AddCookie()
            //    .AddOpenIdConnect(options =>
            //    {
            //        var oidcConfig = builder.Configuration.GetSection("AzureAD");

            //        options.SignInScheme = "Cookies"; // or, CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.Authority = oidcConfig["Instance"];  // "- your-identity-provider-";
            //        options.RequireHttpsMetadata = true;
            //        options.ClientId = oidcConfig["ClientId"]; // "-your-clientid-";
            //        // options.ClientSecret = oidcConfig["ClientSecret"]; //"ffb6f0d3 - 96ad - 4d5f - 829c - 094a6719d26f"; // "-your-client-secret-from-user-secrets-or-keyvault";

            //        options.ResponseType = "code"; // or, OpenIdConnectResponseType.Code;
            //        options.UsePkce = true;
            //        options.Scope.Add("profile");
            //        //options.Scope.Add("email");
            //        //options.Scope.Add("offline_access");

            //        options.ClaimActions.Remove("amr");
            //        options.ClaimActions.MapUniqueJsonKey("website", "website");

            //        options.GetClaimsFromUserInfoEndpoint = true;
            //        options.SaveTokens = true;
            //        // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-oidc-web-authentication?view=aspnetcore-9.0
            //        options.GetClaimsFromUserInfoEndpoint = true;

            //        // .NET 9 feature
            //        options.PushedAuthorizationBehavior = PushedAuthorizationBehavior.Require;


            //        options.MapInboundClaims = false;
            //        options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name; //"name"; 
            //        options.TokenValidationParameters.RoleClaimType = "roles";
            //    });


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
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
