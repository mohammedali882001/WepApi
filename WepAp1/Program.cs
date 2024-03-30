
using Microsoft.EntityFrameworkCore;
using TestingMVC.Repo;
using WepAp1.Models;

namespace WepAp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddDbContext<Context>(optionBiulder =>
            {
                // optionBiulder.UseSqlServer(@"Data Source=.\MSSQLSERVER1;Initial Catalog=MvcCrsTesting;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
                optionBiulder.UseSqlServer(
                        builder.Configuration.GetConnectionString("CS")
                    ); ;
            }

                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
