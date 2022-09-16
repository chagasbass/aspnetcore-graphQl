namespace Aspnecore.GraphQL.API.Domain.Schemas;

//configuração da documentação do schema
public class DomainSchema : Schema
{
    public DomainSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        //add as queries criadas e as mutations
        Query = serviceProvider.GetRequiredService<ProdutoCoresQuery>();
        Mutation = serviceProvider.GetRequiredService<DomainMutation>();
    }
}