using Microsoft.AspNetCore.Builder;
using RestaurantAPI.Core.Application.Mappings;
using RestaurantAPI.Infrastructure.Identity;
using RestaurantAPI.Infrastructure.Persistence;
using RestaurantAPI.WebAPI.Extensions;
using System.Threading.Tasks;

namespace RestaurantAPI.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddIdentityInfrastructure(builder.Configuration);
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddSwaggerExtension();
            builder.Services.AddApiVersioningExtension();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            await app.Services.RunAsyncSeed();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseSwaggerExtension();
            app.UseHealthChecks("/health");

            app.MapControllers();

            app.Run();
        }
    }
}
