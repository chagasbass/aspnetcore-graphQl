using Aspnecore.GraphQL.API.Domain.Mutations;

namespace Aspnecore.GraphQL.API.Domain.Queries
{
    public class DomainMutation : ObjectGraphType
    {

        public DomainMutation(IProdutoCoresQueryRepository produtoCoresQueryRepository)
        {
            var produtoCoresArguments = new QueryArguments(new QueryArgument<NonNullGraphType<ProdutoCoresInputType>> { Name = "produtoCores" });


            //    Field<ProdutoCoresType>(
            //    "criarProdutoCores",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProdutoCoresInputType>> { Name = "criarProdutoCores" }),
            //    resolve: context =>
            //    {
            //        var owner = context.GetArgument<Owner>("owner");
            //        return repository.CreateOwner(owner);
            //    }
            //);

            FieldAsync<ProdutoCoresType>(
           name: "salvarProdutoCores",
           arguments: produtoCoresArguments,
           resolve: async context => await produtoCoresQueryRepository.
                                           SalvarProdutoCoresAsync(context.GetArgument<ProdutoCores>("produtoCores")));
        }
    }
}
