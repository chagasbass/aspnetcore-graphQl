using System.Linq.Expressions;
using Wise.Produtos.Domain.Entidades;

namespace Aspnecore.GraphQL.API.Domain.Specs
{
    public class ProdutoCoresSpec
    {
        public static Expression<Func<ProdutoCores, bool>> ListarProdutosPorProdutoCor(string produtoCor)
        {
            return x => x.CorProduto.ToLower().Equals(produtoCor.ToLower());
        }

        public static Expression<Func<ProdutoCores, bool>> ListarProdutosPorProduto(string produto)
        {
            return x => x.Produto.ToLower().Equals(produto.ToLower());
        }
        public static IEnumerable<ProdutoCores> ListarProdutosPorProdutoCores(IQueryable<ProdutoCores> produtoCoresQueryable, List<string> produtoCores)
        {
            return produtoCoresQueryable.Where(x => produtoCores.Contains(x.CorProduto)).ToList();
        }
    }
}
