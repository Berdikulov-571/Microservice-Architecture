FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiGetaway/ApiGetaway/ApiGetaway.csproj", "src/ApiGetaway/ApiGetaway/"]
RUN dotnet restore "./src/ApiGetaway/ApiGetaway/./ApiGetaway.csproj"
COPY . .
WORKDIR "/src/src/ApiGetaway/ApiGetaway"
RUN dotnet build "./ApiGetaway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiGetaway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGetaway.dll"]