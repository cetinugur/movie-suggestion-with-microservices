#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MovieService/Services.Movie.Api/Services.Movie.Api.csproj", "MovieService/Services.Movie.Api/"]
COPY ["MovieService/Services.Movie.Repositories/Services.Movie.Repositories.csproj", "MovieService/Services.Movie.Repositories/"]
COPY ["MovieService/Services.Movie.Model/Services.Movie.Model.csproj", "MovieService/Services.Movie.Model/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["MovieService/Services.Movie.Data/Services.Movie.Data.csproj", "MovieService/Services.Movie.Data/"]
RUN dotnet restore "MovieService/Services.Movie.Api/Services.Movie.Api.csproj"
COPY . .
WORKDIR "/src/MovieService/Services.Movie.Api"
RUN dotnet build "Services.Movie.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Movie.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Movie.Api.dll"]