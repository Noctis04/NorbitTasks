FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

WORKDIR /app

# COPY .sln file
COPY *.sln .

# COPY .csproj file
COPY BookService.Host/*.csproj ./BookService.Host/
COPY BookService.Domain/*.csproj ./BookService.Domain/
COPY BookService.Infastructure/*.csproj ./BookService.Infastructure/

# Restore dependencies
RUN dotnet restore -r alpine-x64

COPY BookService.Host/. ./BookService.Host/
COPY BookService.Domain/. ./BookService.Domain/
COPY BookService.Infastructure/. ./BookService.Infastructure/

# Build project
RUN dotnet build

# Publish result artifact
RUN dotnet publish -c Release -o /out -r alpine-x64

# Final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine AS publish

WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["./BookService.Host"]