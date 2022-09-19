namespace Aspnecore.GraphQL.API.Infrastructure.Data.Repositories;

public class ProdutoCoresQueryRepository : IProdutoCoresQueryRepository
{
    private readonly GraphDataContext _context;
    private readonly ContextoDeDados _contexto;

    public ProdutoCoresQueryRepository(GraphDataContext context, ContextoDeDados contexto)
    {
        _context = context;
        _contexto = contexto;
    }

    public async Task<IEnumerable<ProdutoCores>> ListarProdutoCoresAsync()
    {
        var lista = await _context.ProdutosCores.AsNoTracking().ToListAsync();

        return lista;
    }

    public async Task<ProdutoCores> ListarProdutoCoresPorCoresProdutosAsync(Expression<Func<ProdutoCores, bool>> expression)
    {
        var dado = await _context.ProdutosCores.AsNoTracking().FirstOrDefaultAsync(expression);
        return dado;
    }

    public async Task<IEnumerable<ProdutoCores>> ListarProdutoCoresAsync(List<string> coresProdutos)
    {
        coresProdutos = coresProdutos.ConvertAll(x => x.ToLower());

        var listaQueryable = _context.ProdutosCores.AsQueryable();

        var lista = ProdutoCoresSpec.ListarProdutosPorProdutoCores(listaQueryable, coresProdutos);

        return lista;
    }

    public async Task<ProdutoCores> ListarProdutoCoresPorProdutoAsync(Expression<Func<ProdutoCores, bool>> expression)
    {
        var dado = await _context.ProdutosCores.FirstOrDefaultAsync(expression);
        return dado;
    }

    public async Task<IEnumerable<ProdutoCores>> ListarProdutoPorGriffeECartelaAsync(List<string> griffes, List<string> cartelas, int rowsPage, int pageNumber, string ordenacao, string tipoOrdenacao)
    {
        try
        {
            using var conexao = _contexto.AbrirConexao();

            var rows = rowsPage;
            var fetch = pageNumber;

            var parametros = new { griffes, cartelas, rowsPage, pageNumber };

            var query = ProdutoCoresQueryHelper.ListarProdutoCores(ordenacao, tipoOrdenacao);

            var produtosCores = await conexao.QueryAsync<ProdutoCores>(query, parametros);

            return produtosCores;
        }
        catch (Exception ex)
        {
            var a = ex;
            throw;
        }
    }

    public async Task<ProdutoCores> SalvarProdutoCoresAsync(ProdutoCores produtoCores)
    {
        //Simulando A inserção
        //using var conexao = _contexto.AbrirConexao();
        var parametros = new { produtoCores };
        var query = "";

        //await conexao.ExecuteAsync(query, parametros);

        return produtoCores;
    }
}