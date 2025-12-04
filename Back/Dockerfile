# Imagen del SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el csproj y restaura dependencias
COPY Back.csproj .
RUN dotnet restore

# Copia todo y compila
COPY . .
RUN dotnet publish -c Release -o /app

# Imagen final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app .

# Render expone el puerto 10000 por defecto en Docker
EXPOSE 8080

# Define variable de entorno de ASP.NET
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Back.dll"]
