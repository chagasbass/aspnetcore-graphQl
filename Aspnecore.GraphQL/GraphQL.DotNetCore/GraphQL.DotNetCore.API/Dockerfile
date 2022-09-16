#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GraphQL.DotNetCore.csproj", "."]
COPY ["GraphQL.DotNetCore.Api/GraphQL.DotNetCore.Api", "GraphQL.DotNetCore.Api/"]
COPY ["GraphQL.DotNetCore.Tests/GraphQL.DotNetCore.Tests.csproj", "GraphQL.DotNetCore.Tests/"]
COPY ["RestoqueMinimal.Extensions/RestoqueMinimal.Extensions.csproj", "RestoqueMinimal.Extensions/"]
RUN dotnet restore "./GraphQL.DotNetCore.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GraphQL.DotNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQL.DotNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL.DotNetCore.dll"]