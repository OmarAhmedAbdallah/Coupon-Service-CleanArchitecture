using MicanoStore.Services.Discount.Application.Constants;
using MicanoStore.Services.Discount.Application.Models;
using MicanoStore.Services.Discount.Infrastructure;
using MicanoStore.Services.Discount.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace MicanoStore.Services.CouponAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var Configuration = builder.Configuration;

        builder.Services.AddControllers();

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.RegisterCustomServices();


        //add connection with database
        string? StringConnection = Configuration[$"{Constant.ConnectionStrings}:{Constant.DatabaseConnection}"];

        builder.Services.AddDbContext<DiscountDbContext>(optionsBuilder => {
            optionsBuilder.UseSqlServer(StringConnection);
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.Configure<Config>(Configuration.GetSection(Constant.ConnectionStrings));

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