FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

WORKDIR /app

# COPY .sln file
COPY *.sln .

# COPY .csproj file
COPY UserService.Host/*.csproj ./UserService.Host/
COPY UserService.Domain/*.csproj ./UserService.Domain/
COPY UserService.Infrastructure/*.csproj ./UserService.Infrastructure/

# Restore dependencies
RUN dotnet restore -r alpine-x64

COPY UserService.Host/. ./UserService.Host/
COPY UserService.Domain/. ./UserService.Domain/
COPY UserService.Infrastructure/. ./UserService.Infrastructure/

# Build project
RUN dotnet build

# Publish result artifact
RUN dotnet publish -c Release -o /out -r alpine-x64

# Final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine AS publish

WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["./UserService.Host"]