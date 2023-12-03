FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/University.Platform/University.Api/University.Api.csproj", "src/University.Platform/University.Api/"]
RUN dotnet restore "./src/University.Platform/University.Api/./University.Api.csproj"
COPY . .
WORKDIR "/src/src/University.Platform/University.Api"
RUN dotnet build "./University.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./University.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "University.Api.dll"]