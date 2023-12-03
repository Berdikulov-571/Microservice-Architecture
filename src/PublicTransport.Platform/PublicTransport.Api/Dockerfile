FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PublicTransport.Platform/PublicTransport.Api/PublicTransport.Api.csproj", "src/PublicTransport.Platform/PublicTransport.Api/"]
RUN dotnet restore "./src/PublicTransport.Platform/PublicTransport.Api/./PublicTransport.Api.csproj"
COPY . .
WORKDIR "/src/src/PublicTransport.Platform/PublicTransport.Api"
RUN dotnet build "./PublicTransport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PublicTransport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PublicTransport.Api.dll"]