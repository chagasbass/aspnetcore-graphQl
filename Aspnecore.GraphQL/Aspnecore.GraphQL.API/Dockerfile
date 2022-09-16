#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aspnecore.GraphQL.csproj", "."]
COPY ["Aspnecore.GraphQL.Api/Aspnecore.GraphQL.Api", "Aspnecore.GraphQL.Api/"]
COPY ["Aspnecore.GraphQL.Tests/Aspnecore.GraphQL.Tests.csproj", "Aspnecore.GraphQL.Tests/"]
COPY ["RestoqueMinimal.Extensions/RestoqueMinimal.Extensions.csproj", "RestoqueMinimal.Extensions/"]
RUN dotnet restore "./Aspnecore.GraphQL.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Aspnecore.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aspnecore.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aspnecore.GraphQL.dll"]