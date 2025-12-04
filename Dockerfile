# Imagen base de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar el archivo csproj desde la carpeta Back
COPY Back/Back.csproj Back/

# Restaurar dependencias
RUN dotnet restore Back/Back.csproj

# Copiar TODO el proyecto Back
COPY Back/ Back/

# Publicar
RUN dotnet publish Back/Back.csproj -c Release -o /app/publish

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Back.dll"]

