namespace Wise.Produtos.Domain.Entidades;

public class ProdutoCores : WiseBase
{
    public string? Produto { get; set; }
    public string? CorProduto { get; set; }
    public DateTime? FimVendas { get; set; }
    public string? DescCorProduto { get; set; }

    public ProdutoCores() { }

}
