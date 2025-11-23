# ===============================
# STAGE 1: Build the application
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["DotnetWebAppToKubernetes.csproj", "./"]
RUN dotnet restore

# Copy everything else and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# ===============================
# STAGE 2: Runtime image
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the build output
COPY --from=build /app/publish .

# Expose ports
EXPOSE 80
EXPOSE 443

# Environment variable for database connection
# (Kubernetes will override this)
ENV ConnectionStrings__DefaultConnection="Host=postgres;Port=5432;Database=MyWebAppDB;Username=postgres;Password=postgres"

# Start the app
ENTRYPOINT ["dotnet", "DotnetWebAppToKubernetes.dll"]
