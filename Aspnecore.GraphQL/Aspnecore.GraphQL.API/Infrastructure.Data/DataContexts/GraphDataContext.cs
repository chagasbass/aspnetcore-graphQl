using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wise.Produtos.Domain.Entidades;

namespace Aspnecore.GraphQL.API.Infrastructure.Data.DataContexts
{
    public class GraphDataContext : DbContext
    {
        public DbSet<ProdutoCores> ProdutosCores { get; set; }

        public GraphDataContext(DbContextOptions<GraphDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
