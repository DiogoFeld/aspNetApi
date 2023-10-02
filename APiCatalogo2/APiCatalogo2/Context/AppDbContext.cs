using APiCatalogo2.Model;
using Microsoft.EntityFrameworkCore;

namespace APiCatalogo2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        //sobreescreve o entityFramwork
        protected override void OnModelCreating(ModelBuilder mb)
        {

            //categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaID);

            mb.Entity<Categoria>().Property(c => c.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            //produto
            mb.Entity<Produto>().Property(c => c.ProdutoId);
            mb.Entity<Produto>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();
            mb.Entity<Produto>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produto>().Property(c => c.imagem).HasMaxLength(150);

            mb.Entity<Produto>().Property(c => c.Preco).HasPrecision(14, 2);


            //relacionamento

            mb.Entity<Produto>().HasOne<Categoria>(c => c.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.CaregoriaId);


        }


    }
}
