using Aspnecore.GraphQL.API.Domain.Schemas;
using Aspnecore.GraphQL.API.Extensions;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using RestoqueMinimal.Extensions.CustomResults;
using RestoqueMinimal.Extensions.Documentations;
using RestoqueMinimal.Extensions.Logs;
using RestoqueMinimal.Extensions.Middlewares;
using RestoqueMinimal.Extensions.Observability.Healthchecks;
using RestoqueMinimal.Extensions.Options;
using RestoqueMinimal.Extensions.Performances;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = LogIntegrationsExtensions.ConfigureStructuralLogWithSerilog();
builder.Logging.AddSerilog(Log.Logger);

try
{
    var configuration = builder.Configuration;

    #region configuracoes das extensoes

    /*A extension do application Insights s� deve ser inserida quando a chave estiver no appSettings
    *.AddApplicationInsightsApiTelemetry(configuration)
    * 
    *Caso seja necess�rio usar a extension para resili�ncia em chamadas htttp ativar a extension
    *AddWorkerResiliencesPatterns
    * 
    * Existe uma implementa��o de log mais simples usando o padr�o
    * do aspnetCore. Caso queira usa-lo 
    * as configura��es do serilog devem ser retiradas e o servi�o de log deve ser reimplementado
    * o try catch n�o � mais necess�rio
    * retirar a execu��o da extension :
    * adicionar na pilha a extension AddMinimalApiAspNetCoreHttpLogging
    */

    builder.Services.AddEndpointsApiExplorer()
                .AddBaseConfigurationOptionsPattern(configuration)
                .AddSwaggerDocumentation(configuration)
                .AddLogServiceDependencies()
                .AddNotificationControl()
                .AddAppHealthChecks()
                .AddMinimalApiPerformanceBoost()
                .AddDependencyInjection(configuration)
                .AddApiCustomResults()
                .AddGlobalExceptionHandlerMiddleware()
                .AddApiVersioning(x => x.DefaultApiVersion = ApiVersion.Default);

    //vai virar extension
    builder.Services.AddGraphQL(x => x.EnableMetrics = false)
                    .AddSystemTextJson()
                    .AddGraphTypes(typeof(DomainSchema), ServiceLifetime.Scoped);

    #endregion

    var app = builder.Build();

    #region configuracoes dos middlewares

    app.UseResponseCompression()
       .UseMiddleware<GlobalExceptionHandlerMiddleware>()
       .UseMiddleware<SerilogRequestLoggerMiddleware>()
       .UseHealthChecks(configuration)
       .UseHttpsRedirection();

    //app.UseGraphQLAltair();
    app.UseGraphQL<ISchema>();
    app.UseGraphQLPlayground(
    "/api",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

    #endregion

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminado inexperadamente.");
}
finally
{
    Log.CloseAndFlush();
}

