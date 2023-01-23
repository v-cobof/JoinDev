using JoinDev.Infra.Data;
using JoinDev.Infra.Data.Read;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void ConfigureWriteDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<JoinDevContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void ConfigureReadDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection("MongoDB");
            services.Configure<ReadDatabaseSettings>(mongoDbSettings);
            services.AddScoped<MongoDbContext>();
        }
    }
}
