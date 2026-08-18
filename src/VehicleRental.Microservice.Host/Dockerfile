#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0.0-noble-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0.100-noble-amd64 AS build
ARG PersonalAccessToken
WORKDIR /src
COPY Directory.Build.* ./
COPY NuGet.config .
COPY ["src/VehicleRental.Microservice.Host/VehicleRental.Microservice.Host.csproj", "VehicleRental.Microservice.Host/"]
COPY ["src/VehicleRental.Microservice.Api/VehicleRental.Microservice.Api.csproj", "VehicleRental.Microservice.Api/"]
COPY ["src/VehicleRental.Microservice.ApplicationCore/VehicleRental.Microservice.ApplicationCore.csproj", "VehicleRental.Microservice.ApplicationCore/"]
COPY ["src/VehicleRental.Microservice.Infrastructure/VehicleRental.Microservice.Infrastructure.csproj", "VehicleRental.Microservice.Infrastructure/"]
RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS "{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/gtmotive/_packaging/GtMotivePackages/nuget/v3/index.json\", \"password\":\"${PersonalAccessToken}\"}]}"
RUN dotnet restore "VehicleRental.Microservice.Host/VehicleRental.Microservice.Host.csproj"
RUN dotnet restore "VehicleRental.Microservice.Api/VehicleRental.Microservice.Api.csproj"
RUN dotnet restore "VehicleRental.Microservice.ApplicationCore/VehicleRental.Microservice.ApplicationCore.csproj"
RUN dotnet restore "VehicleRental.Microservice.Infrastructure/VehicleRental.Microservice.Infrastructure.csproj"
COPY src .
COPY . .
WORKDIR "/src/VehicleRental.Microservice.Host"
RUN dotnet build "VehicleRental.Microservice.Host.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/VehicleRental.Microservice.Host"
RUN dotnet publish "VehicleRental.Microservice.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleRental.Microservice.Host.dll"]
USER nobody