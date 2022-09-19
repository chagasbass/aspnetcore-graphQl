namespace Aspnecore.GraphQL.API.Domain.Queries;

/// <summary>
/// //Responsável por recuperar os dados(contém as queries da entidade
/// </summary>
public class ProdutoCoresQuery : ObjectGraphType
{
    public ProdutoCoresQuery(IProdutoCoresQueryRepository produtoCoresQueryRepository)
    {
        Field<ListGraphType<ProdutoCoresType>>(Name = "produtoCores", resolve: x => produtoCoresQueryRepository.ListarProdutoCoresAsync());

        var _argumentCorProduto = new QueryArguments(new QueryArgument<StringGraphType> { Name = "corProduto" });
        var _argumentProduto = new QueryArguments(new QueryArgument<StringGraphType> { Name = "produto" });
        var _argumentsCoresProdutos = new QueryArguments(new QueryArgument<ListGraphType<StringGraphType>> { Name = "cores" });

        var prametrosGriffesCartelasComPaginacao = new QueryArguments
        {
            new QueryArgument<ListGraphType<StringGraphType>> { Name = "griffes" },
             new QueryArgument<ListGraphType<StringGraphType>> { Name = "cartelas" },
             new QueryArgument<IntGraphType> { Name = "rowsPage",DefaultValue = 10 },
             new QueryArgument<IntGraphType> { Name = "pageNumber" ,DefaultValue = 1},
             new QueryArgument<StringGraphType>{Name = "orderBy",DefaultValue = "produto"},
             new QueryArgument<StringGraphType>{Name = "orderType",DefaultValue = "ASC"}
        };

        FieldAsync<ProdutoCoresType>(
            name: "listarProdutoCor",
            arguments: _argumentCorProduto,
            resolve: async context => await produtoCoresQueryRepository.ListarProdutoCoresPorCoresProdutosAsync(
                ProdutoCoresSpec.ListarProdutosPorProdutoCor(context.GetArgument<string>("corProduto"))));

        FieldAsync<ProdutoCoresType>(
            name: "listarProdutos",
            arguments: _argumentProduto,
            resolve: async context => await produtoCoresQueryRepository.ListarProdutoCoresPorCoresProdutosAsync(
                ProdutoCoresSpec.ListarProdutosPorProduto(context.GetArgument<string>("produto"))
                ));

        FieldAsync<ListGraphType<ProdutoCoresType>>(
            name: "listarProdutoCorPorCores",
            arguments: _argumentsCoresProdutos,
            resolve: async context => await produtoCoresQueryRepository.ListarProdutoCoresAsync(
                context.GetArgument<List<string>>("cores")));

        FieldAsync<ListGraphType<ProdutoCoresType>>(
            name: "listarProdutoCorPorGriffeRCartelasComPaginacao",
            arguments: prametrosGriffesCartelasComPaginacao,
            resolve: async context => await produtoCoresQueryRepository.ListarProdutoPorGriffeECartelaAsync(
                context.GetArgument<List<string>>("griffes"),
                context.GetArgument<List<string>>("cartelas"),
                context.GetArgument<int>("rowsPage"),
                context.GetArgument<int>("pageNumber"),
                context.GetArgument<string>("orderBy"),
                context.GetArgument<string>("orderType")));
    }
}
