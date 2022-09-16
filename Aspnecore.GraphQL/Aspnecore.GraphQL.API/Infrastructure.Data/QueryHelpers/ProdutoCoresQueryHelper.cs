namespace Wise.Produtos.Infrastructure.Data.QueryHelpers;

public static class ProdutoCoresQueryHelper
{
    public static string ListarProdutoCores()
    {
        var query = new StringBuilder();

        query.AppendLine(" SELECT ");
        query.AppendLine(" WS_PRODUTOS.Produto as Produto");
        query.AppendLine(" ,WS_PRODUTO_CORES.COR_PRODUTO as CorProduto");
        query.AppendLine(" ,WS_PRODUTO_CORES.FIM_VENDAS as FimVendas");
        query.AppendLine(" ,WS_PRODUTO_CORES.DESC_COR_PRODUTO as DescCorProduto");
        query.AppendLine(" FROM dbo.WS_PRODUTOS WITH (NOLOCK)");
        query.AppendLine(" INNER JOIN WS_PRODUTO_CORES");
        query.AppendLine(" ON WS_PRODUTO_CORES.Produto = WS_PRODUTOS.Produto");
        query.AppendLine(" WHERE WS_PRODUTOS.PRODUTO in (SELECT DISTINCT WS_PRODUTOS.PRODUTO FROM WS_PRODUTOS ");
        query.AppendLine(" LEFT JOIN WS_ESTOQUE_PRODUTOS on WS_PRODUTOS.PRODUTO = WS_ESTOQUE_PRODUTOS.PRODUTO ");
        query.AppendLine(" WHERE(isnull(WS_ESTOQUE_PRODUTOS.PRONTA_ENTREGA, 0) = 1 and WS_ESTOQUE_PRODUTOS.ESTOQUE > 0) or isnull(WS_ESTOQUE_PRODUTOS.PRONTA_ENTREGA,0) = 0) ");
        query.AppendLine(" AND WS_PRODUTOS.GRIFFE IN @GRIFFES AND WS_PRODUTOS.CARTELA IN @CARTELAS ");
        query.AppendLine(" ORDER BY WS_PRODUTOS.PRODUTO");
        query.AppendLine(" OFFSET ((@PageNumber - 1) * @RowsPage) ROWS");
        query.AppendLine(" FETCH NEXT @RowsPage ROWS ONLY");

        return query.ToString();
    }
}