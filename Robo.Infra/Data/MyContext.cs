using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Robo.Domain.Entities;

namespace Robo.Infra.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Braco> Bracos { get; set; }
        public DbSet<Cabeca> Cabeca { get; set; }
        public DbSet<Cotovelo> Cotovelos { get; set; }
        public DbSet<Pulso> Pulsos { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public MyContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("connectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
