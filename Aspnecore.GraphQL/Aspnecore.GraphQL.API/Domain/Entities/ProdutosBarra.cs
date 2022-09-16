namespace Wise.Produtos.Domain.Entidades;

public class ProdutosBarra : WiseBase
{
    public string? Produto { get; set; }
    public string? CodigoBarra { get; set; }
    public string? Cor { get; set; }
    public int Tamanho { get; set; }

    public ProdutosBarra() { }

}
