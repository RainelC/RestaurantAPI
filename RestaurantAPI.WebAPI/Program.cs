using Microsoft.AspNetCore.Builder;
using RestaurantAPI.Core.Application.Mappings;
using RestaurantAPI.Infrastructure.Persistence;
using RestaurantAPI.WebAPI.Extensions;

namespace RestaurantAPI.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();
            builder.Services.AddPersistenceLayer(builder.Configuration);
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseHealthChecks("/health");
            app.UseSession();

            app.MapControllers();

            app.Run();
        }
    }
}
