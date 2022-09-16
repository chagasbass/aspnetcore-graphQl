namespace Wise.Produtos.Domain.Entidades;

public class WiseProduto : WiseBase
{
    public string? Produto { get; set; }
    public string? ClassifFiscal { get; set; }
    public int SexoTipo { get; set; }
    public string? PeriodoPcp { get; set; }
    public string? TipoProduto { get; set; }
    public string? Fabricante { get; set; }
    public string? DescProduto { get; set; }
    public string? GrupoProduto { get; set; }
    public string? SubGrupoProduto { get; set; }
    public string? StatusProduto { get; set; }
    public string? DescProdNf { get; set; }
    public string? Griffe { get; set; }
    public string? Linha { get; set; }
    public string? Grade { get; set; }
    public string? Obs { get; set; }
    public string? VariaPrecoCor { get; set; }
    public string? Cartela { get; set; }
    public string? ComposicaoAuxiliar { get; set; }
    public string? Colecao { get; set; }
    public string? DescStatusProduto { get; set; }

    public WiseProduto() { }

}
