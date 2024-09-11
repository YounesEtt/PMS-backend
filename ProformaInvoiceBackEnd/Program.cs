using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProformaInvoiceBackEnd.Helpers;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        // Auto mapper
        builder.Services.AddAutoMapper(typeof(Program));

        // Add DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection")));

        // Add JWT Authentication
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false; // Set to true in production
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };
        });

        // Register services
        builder.Services.AddScoped<AutoMapperProfile>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<plantService>();
        builder.Services.AddScoped<DepartementService>();
        builder.Services.AddScoped<ScenarioService>();
        builder.Services.AddScoped<RequestService>();
        builder.Services.AddScoped<RequestItemService>();
        builder.Services.AddScoped<scenarioItemsconfigurationservice>();
        builder.Services.AddScoped<ApproverScenarioService>();
        builder.Services.AddScoped<UserPlantService>();
        builder.Services.AddScoped<ShipPointService>();
        builder.Services.AddScoped<ApproverRequestService>();
        builder.Services.AddScoped<KPIsService>();

        // Add CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AngularApp", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });
        }

        app.UseHttpsRedirection();

        // Use CORS
        app.UseCors("AngularApp");

        // Use Authentication and Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        // Map controllers
        app.MapControllers();

        app.Run();
    }
}