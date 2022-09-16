namespace Wise.Produtos.Domain.Entidades;

public class ProdutoPrecos : WiseBase
{
    public string Produto { get; set; }
    public string PromocaoDesconto { get; set; }
    public string Preco1 { get; set; }
    public string CodigoTabPreco { get; set; }

    public ProdutoPrecos() { }
}
