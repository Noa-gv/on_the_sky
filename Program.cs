
using on_the_sky.core.repositories;
using on_the_sky.core.services;
using on_the_sky.Data.repositories;
using on_the_sky.service;

namespace on_the_sky
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
           
            builder.Services.AddScoped<IFlightService,FlightServicecs>();
            builder.Services.AddScoped<IFlightRepository, FlightRepositories>();
            builder.Services.AddScoped<IplaceService, PlaceServicecs>();
            builder.Services.AddScoped<IplaceRepository, PlaceRepositories>();
            builder.Services.AddScoped<ItravelService, TravelServicecs>();
            builder.Services.AddScoped<ITravelRepository, TravelRipositories>();
            builder.Services.AddDbContext<Datacontext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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