using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Robo.Core.Configurations.Database
{
    public static class DbConfigurationDependency
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connect = configuration["sqlDb:connectionString"];
            services.AddScoped(c =>
            {
                return new SqlConnection(connect);
            });
            services.AddScoped<IDbConnection>(c =>
            {
                var dbConnection = c.GetService<SqlConnection>();
                dbConnection.Open();

                return dbConnection;
            });

            services.AddScoped(c =>
            {
                return c.GetService<IDbConnection>().BeginTransaction();
            });
        }
    }
}
