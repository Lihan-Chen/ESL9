
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using ESL.Infrastructure.DataAccess.Repositories;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DbContextPool for Oracle
            builder.Services.AddDbContextPool<EslDbContext>(options =>
            { options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")); }, poolSize: 128);
            //options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")));

            builder.Services.AddDbContextPool<EslViewContext>(options =>
            { options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")); }, poolSize: 128);
            //options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")));

            // DbContext for Oracle
            //builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmpRoleRepository, EmpRoleRepository>();
            builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            builder.Services.AddScoped<ILogTypeRepository, LogTypeRepository>();
            //builder.Services.AddScoped<IMeterRepository, MeterRepository>();
            builder.Services.AddScoped<IAllEventRepository, AllEventRepository>();

            builder.Services.AddScoped<ICoreService, CoreService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESL API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
