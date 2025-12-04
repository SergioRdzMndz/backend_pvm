using Back.Data;
using Back.Services;
using Microsoft.EntityFrameworkCore;

namespace Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<PvmContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PvmContext"));
            });

            // Add ordering services
            builder.Services.AddScoped<IPedidosService, PedidosService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
