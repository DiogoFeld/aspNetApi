using APiCatalogo2.Model;
using Microsoft.EntityFrameworkCore;

namespace APiCatalogo2.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

        }


    }
}
