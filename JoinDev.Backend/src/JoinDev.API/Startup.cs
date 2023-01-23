﻿using JoinDev.API.Configurations;
using JoinDev.Infra.Data;
using Microsoft.EntityFrameworkCore;
using JoinDev.API.Security;
using JoinDev.Infra.Data.Read;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace JoinDev.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureWriteDatabase(Configuration);
            services.ConfigureReadDatabase(Configuration);

            services.AddBusConfiguration();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSecurityConfig(Configuration);

            services.AddDependencyInjectionConfiguration();
        }

        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
