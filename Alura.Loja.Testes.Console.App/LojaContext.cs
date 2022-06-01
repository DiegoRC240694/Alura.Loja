using Alura.Loja.Testes.Console.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        //private IConfiguration _configuration;
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Compra>? Compras { get; set; }  
        public DbSet<Promocao>? Promocoes { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }

        //public LojaContext()
        //{ }

        //public LojaContext(DbContextOptions<LojaContext> options, IConfiguration configuration) : base(options)
        //{
        //    _configuration = configuration;
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        optionsBuilder
        //            .UseNpgsql("Server=localhost;Port=5432;User id=postgres;Password=didi240694;Database=LojaDB;");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User id=postgres;Password=didi240694;Database=LojaDB;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            modelBuilder.Entity<Endereco>().ToTable("Enderecos");

            modelBuilder.Entity<Endereco>().Property<int>("ClienteId");

            modelBuilder.Entity<Endereco>().HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }

       

       



    }
}