#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6060
ENV ASPNETCORE_URLS=http://*:6060

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PruebaTecnica.WebApi/PruebaTecnica.WebApi.csproj", "src/PruebaTecnica.WebApi/"]
COPY ["src/PruebaTecnica.Application/PruebaTecnica.Application.csproj", "src/PruebaTecnica.Application/"]
COPY ["src/PruebaTecnica.Domain/PruebaTecnica.Domain.csproj", "src/PruebaTecnica.Domain/"]
COPY ["src/PruebaTecnica.Infrastructure/PruebaTecnica.Infrastructure.csproj", "src/PruebaTecnica.Infrastructure/"]
RUN dotnet restore "src/PruebaTecnica.WebApi/PruebaTecnica.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PruebaTecnica.WebApi"
RUN dotnet build "PruebaTecnica.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaTecnica.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaTecnica.WebApi.dll"]