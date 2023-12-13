using Autorization.Api.DataContexts;
using Autorization.Api.Interfaces;
using Autorization.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Autorization.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddDbContext<KadastrDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Kadastr")));
            builder.Services.AddDbContext<SchoolDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("School")));
            builder.Services.AddDbContext<UniversityDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("University")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
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
