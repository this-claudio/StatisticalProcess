# Imagem base de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet publish "StatisticalProcess.API/StatisticalProcess.API.csproj" -c Release -o /app/publish

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN ls
ENTRYPOINT ["dotnet", "StatisticalProcess.API.dll"]
