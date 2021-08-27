using Microsoft.EntityFrameworkCore;
using ClienteDemo.Infrastucture.Models;

namespace ClienteDemo.Infrastucture
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }

        protected override  void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<ClienteModel>().HasIndex(c => c.Cliente).IsUnique();
        }
    }
}
