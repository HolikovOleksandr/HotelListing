using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.Models;
using HotelListing.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connection = builder.Configuration.GetConnectionString("Sql");
        builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connection));

        builder.Services.AddAutoMapper(typeof(MapperInitializer));

        builder.Services.AddControllers().AddNewtonsoftJson(o =>
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        );

        builder.Services.AddCors(o =>
        {
            o.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddSwaggerGen();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();
        app.MapControllers();

        try
        {
            Log.Information("Application was staring");
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application failed to start");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}