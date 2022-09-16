namespace Aspnecore.GraphQL.API.Domain.Mutations;

/// <summary>
/// Classe mutation para inserir um novo ProdutoCor
/// </summary>
public class ProdutoCoresInputType : InputObjectGraphType
{
    public ProdutoCoresInputType()
    {
        Name = "ProdutoCoresInput";
        Field<NonNullGraphType<StringGraphType>>("produto");
        Field<NonNullGraphType<StringGraphType>>("corProduto");
        Field<NonNullGraphType<StringGraphType>>("descCorProduto");
        Field<NonNullGraphType<DateGraphType>>("fimVendas");
    }
}
