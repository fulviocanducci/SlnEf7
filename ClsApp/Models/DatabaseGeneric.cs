using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
//https://www.youtube.com/watch?v=ss1ufTOjeq8
namespace ClsApp.Models
{
    public class DatabaseGeneric : DbContext
    {
        public DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=MyDataBase;User Id=sa;Password=senha;Encrypt=false")
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(config =>
            {
                config.ToTable("Peoples");
                config.HasKey(x => x.Id);
                config.Property(x => x.Id);
                config.Property(x => x.Name).IsRequired().HasMaxLength(100);
                config.Property(x => x.Status).IsRequired();
            });
        }
    }
}
