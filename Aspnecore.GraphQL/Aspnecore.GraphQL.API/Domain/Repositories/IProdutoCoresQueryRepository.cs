namespace Aspnecore.GraphQL.API.Domain.Repositories;

public interface IProdutoCoresQueryRepository
{
    Task<IEnumerable<ProdutoCores>> ListarProdutoCoresAsync();
    Task<ProdutoCores> ListarProdutoCoresPorCoresProdutosAsync(Expression<Func<ProdutoCores, bool>> expression);
    Task<ProdutoCores> ListarProdutoCoresPorProdutoAsync(Expression<Func<ProdutoCores, bool>> expression);
    Task<IEnumerable<ProdutoCores>> ListarProdutoCoresAsync(List<string> coresProdutos);
    Task<IEnumerable<ProdutoCores>> ListarProdutoPorGriffeECartelaAsync(List<string> griffes, List<string> cartelas, int rowsPage, int pageNumber, string ordenacao, string tipoOrdenacao);

    Task<ProdutoCores> SalvarProdutoCoresAsync(ProdutoCores produtoCores);
    //DataLoader
    //Task<ILookup<string, ProdutoCores>> ListarProdutoCoresPorCoresProdutosAsync(string produto);
}
