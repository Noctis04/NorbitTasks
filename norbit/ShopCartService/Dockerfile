FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

WORKDIR /app

# COPY .sln file
COPY *.sln .

# COPY .csproj file
COPY ShopCartService.Host/*.csproj ./ShopCartService.Host/
COPY ShopCartService.Domain/*.csproj ./ShopCartService.Domain/
COPY ShopCardService.Infrastructure/*.csproj ./ShopCardService.Infrastructure/

# Restore dependencies
RUN dotnet restore -r alpine-x64

COPY ShopCartService.Host/. ./ShopCartService.Host/
COPY ShopCartService.Domain/. ./ShopCartService.Domain/
COPY ShopCardService.Infrastructure/. ./ShopCardService.Infrastructure/

# Build project
RUN dotnet build

# Publish result artifact
RUN dotnet publish -c Release -o /out -r alpine-x64

# Final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine AS publish

WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["./ShopCartService.Host"]