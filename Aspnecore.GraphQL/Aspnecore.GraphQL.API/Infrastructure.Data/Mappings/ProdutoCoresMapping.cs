using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wise.Produtos.Domain.Entidades;

namespace Aspnecore.GraphQL.API.Infrastructure.Data.Mappings
{
    public class ProdutoCoresMapping : IEntityTypeConfiguration<ProdutoCores>
    {
        public void Configure(EntityTypeBuilder<ProdutoCores> builder)
        {
            builder.ToTable("WS_PRODUTO_CORES");

            builder.HasNoKey();

            builder.Property(x => x.Produto)
                   .HasColumnName("PRODUTO");

            builder.Property(x => x.DescCorProduto)
                   .HasColumnName("DESC_COR_PRODUTO");

            builder.Property(x => x.CorProduto)
                   .HasColumnName("COR_PRODUTO");

            builder.Property(x => x.FimVendas)
                   .HasColumnName("FIM_VENDAS");
        }
    }
}
