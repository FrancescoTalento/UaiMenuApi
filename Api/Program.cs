
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region ServicesOfDbInteraction
            builder.Services.AddScoped<IAdmService, AdmService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            //builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion
            builder.Services.AddControllers();



            var conn = builder.Configuration.GetConnectionString("Default")
    ?? "Server=127.0.0.1;Port=3306;Database=db_restaurante;User Id=root;Password=rootSenha18@2028";

            builder.Services.AddDbContext<UaiMenuDbContext>(opt =>
                opt.UseMySql(conn, ServerVersion.AutoDetect(conn)));

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
