using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using CoffeeStoreManagementApp.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using CoffeeStoreManagementApp.Services.Interfaces;
using CoffeeStoreManagementApp.Services;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace CoffeeStoreManagementApp
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddLogging(l => l.AddLog4Net());
            var keyVaultUri = builder.Configuration["KeyVault:VaultUri"];
            //var sqlSecretName = builder.Configuration["KeyVault:SecretNames:SqlSecret"];

            var onlinesql = builder.Configuration["KeyVault:SecretNames:OnlineSql"];
            var offlinesql = builder.Configuration["KeyVault:SecretNames:SqlSecret"];
            var jwtSecretName = builder.Configuration["KeyVault:SecretNames:JwtSecret"];

            var blobStringName = builder.Configuration["KeyVault:SecretNames:BlobString"];
            var blobContainerName = builder.Configuration["KeyVault:SecretNames:BlobContainer"];


            var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            var sqlonlieSecret = await client.GetSecretAsync(onlinesql);
            var sqlofflineSecret = await client.GetSecretAsync(offlinesql);

            var jwtSecret = await client.GetSecretAsync(jwtSecretName);


            var blobsecret = await client.GetSecretAsync(blobStringName);
            var blobcontainersecret = await client.GetSecretAsync(blobContainerName);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<CoffeeManagementContext>(
            //options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //);

            #region Context
            builder.Services.AddDbContext<CoffeeManagementContext>(
              options => options.UseSqlServer(sqlonlieSecret.Value.Value)
            );
            #endregion


            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });



            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret.Value.Value)),

                    };

                });

            #region Repository Dependency Injection
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, UserCredential>, UserCredentialRepository>();
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, EmployeeCredential>, EmployeeCredentialRepository>();
            builder.Services.AddScoped<IRepository<int, Coffee>, CoffeeRepository>();
            builder.Services.AddScoped<IRepository<int, Capacity>, CapacityRepository>();
            builder.Services.AddScoped<IRepository<int, Milk>, MilkRepository>();
            builder.Services.AddScoped<IRepository<int, NonDairyAlternative>, NonDairyAlternativeRepository>();
            builder.Services.AddScoped<IRepository<int, Sauce>, SauceRepository>();
            builder.Services.AddScoped<IRepository<int, Topping>, ToppingRepository>();
            builder.Services.AddScoped<IIntermediateModelRepository<int,int, CoffeeCapacity>, CoffeeCapacityRepository>();
            builder.Services.AddScoped<IIntermediateModelRepository<int, int, CoffeeMilk>, CoffeeMilkRepository>();
            builder.Services.AddScoped<IIntermediateModelRepository<int, int, CoffeeNonDairyAlternative>, CoffeeNonDairyAlternativeRepository>();
            builder.Services.AddScoped<IIntermediateModelRepository<int, int, CoffeeSauce>, CoffeeSauceRepsoitory>();
            builder.Services.AddScoped<IIntermediateModelRepository<int, int, CoffeeTopping>, CoffeeToppingRepository>();
            builder.Services.AddScoped<IRepository<int, Cart>, CartRepository>();
            builder.Services.AddScoped<IRepository<int,CartItem>, CartItemRepository>();
            builder.Services.AddScoped<IRepository<int, Order>, OrderRepository>();
            builder.Services.AddScoped<IRepository<int, OrderDetail>, OrderDetailRepository>();
            builder.Services.AddScoped<IRepository<int, OrderDetailStatus>, OrderDetailStatusRepository>();
            #endregion

            #region Service Dependency Injection
            //builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICoffeeServices, CoffeeServices>();
            builder.Services.AddScoped<ICartServices, CartServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
            builder.Services.AddScoped<IBlobService>(provider =>
            {

                return new BlobService(blobsecret.Value.Value, blobcontainersecret.Value.Value);
            });
            builder.Services.AddScoped<ITokenService>(provider =>
            {

                return new TokenService(jwtSecret.Value.Value);
            });

            #endregion

            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyCors");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
