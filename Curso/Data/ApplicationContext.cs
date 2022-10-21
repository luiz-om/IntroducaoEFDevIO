using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; initial Catalog= CursoEFCore; Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // na primeira execução varre a aplicação para encontrar classes que foram implementadas com IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public DbSet<Pedido> Pedidos{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


       
    }
}
