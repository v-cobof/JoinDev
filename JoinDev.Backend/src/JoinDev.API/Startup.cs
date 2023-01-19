using JoinDev.API.Configurations;
using JoinDev.Infra.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using JoinDev.Application.Commands.Handlers;
using JoinDev.API.Security;
using JoinDev.Infra.Data.Read;

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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<JoinDevContext>(options =>
                options.UseSqlServer(connectionString));

            var mongoDbSettings = Configuration.GetSection("MongoDB");
            services.Configure<ReadDatabaseSettings>(mongoDbSettings);
            services.AddScoped<MongoDbContext>();

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
