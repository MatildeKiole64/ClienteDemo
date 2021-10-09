using ClienteDemo.Infrastucture.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteDemo.Infrastucture.Repositorios
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>().HasIndex(c => c.Codigo).IsUnique();
        }
    }
}
