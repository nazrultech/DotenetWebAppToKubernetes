# Use the official .NET 8 SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY DotenetWebAppToKubernetes/*.csproj ./
RUN dotnet restore

# Copy all source and build
COPY DotenetWebAppToKubernetes/. ./
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "DotnetWebAppToKubernetes.dll"]
