namespace Aspnecore.GraphQL.API.Domain.Types;

/// <summary>
/// //classe para mapear a entidade e seus campos do graph
/// </summary>
public class ProdutoCoresType : ObjectGraphType<ProdutoCores>
{
    public ProdutoCoresType()
    {
        Field<StringGraphType>("produto").Description = "Número do produto";
        Field<StringGraphType>("corProduto").Description = "Número da cor do produto";
        Field<StringGraphType>("descCorProduto").Description = "Descrição da cor do produto";
        Field<NonNullGraphType<DateGraphType>>("fimVendas").Description = "Data do fim das vendas";
    }
}