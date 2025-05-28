FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copying project's file to restore
COPY ["src/OrderPackagingService.Api/OrderPackagingService.Api.csproj", "src/OrderPackagingService.Api/"]
COPY ["src/OrderPackagingService.Domain/OrderPackagingService.Domain.csproj", "src/OrderPackagingService.Domain/"]
COPY ["src/OrderPackagingService.Infra/OrderPackagingService.Infra.csproj", "src/OrderPackagingService.Infra/"]
COPY ["src/OrderPackagingService.Shared/OrderPackagingService.Shared.csproj", "src/OrderPackagingService.Shared/"]

# Restoring dependencies
RUN dotnet restore "src/OrderPackagingService.Api/OrderPackagingService.Api.csproj"

# Copying source code
COPY . .

# Build project
# RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "src/OrderPackagingService.Api/OrderPackagingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "src/OrderPackagingService.Api/OrderPackagingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderPackagingService.Api.dll"]