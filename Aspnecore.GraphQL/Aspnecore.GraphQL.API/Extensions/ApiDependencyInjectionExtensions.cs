using Aspnecore.GraphQL.API.Domain.Mutations;

namespace Aspnecore.GraphQL.API.Extensions;

public static class ApiDependencyInjectionExtensions
{
    /// <summary>
    /// Adicionar as dependencias criadas e usadas na aplicação
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration["BaseConfiguration:StringConexaoBancoDeDados"];

        services.AddDbContext<GraphDataContext>(contexto =>
        {
            contexto.UseSqlServer(connectionString);
        });

        services.AddTransient<ContextoDeDados, ContextoDeDados>();
        services.AddTransient<IProdutoCoresQueryRepository, ProdutoCoresQueryRepository>();
        services.AddTransient<ProdutoCoresType>();
        services.AddTransient<ProdutoCoresInputType>();
        services.AddTransient<DomainMutation>();
        services.AddTransient<ProdutoCoresQuery>();
        services.AddTransient<ISchema, DomainSchema>();

        return services;
    }
}