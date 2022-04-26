#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EMailService/Services.EMail.Api/Services.EMail.Api.csproj", "EMailService/Services.EMail.Api/"]
COPY ["Shared/Services.Shared.Authentication.Client/Services.Shared.Authentication.Client.csproj", "Shared/Services.Shared.Authentication.Client/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["EMailService/Services.EMail.EventBus/Services.EMail.EventBus.csproj", "EMailService/Services.EMail.EventBus/"]
COPY ["EMailService/Services.EMail.Services/Services.EMail.Services.csproj", "EMailService/Services.EMail.Services/"]
COPY ["Shared/Services.Shared.Authentication.Helper/Services.Shared.Authentication.Helper.csproj", "Shared/Services.Shared.Authentication.Helper/"]
COPY ["MovieService/Services.Movie.Client/Services.Movie.Client.csproj", "MovieService/Services.Movie.Client/"]
COPY ["Shared/Services.Shared.Client/Services.Shared.Client.csproj", "Shared/Services.Shared.Client/"]
COPY ["MovieService/Services.Movie.Model/Services.Movie.Model.csproj", "MovieService/Services.Movie.Model/"]
COPY ["Shared/Services.Shared.EventBus/Services.Shared.EventBus.csproj", "Shared/Services.Shared.EventBus/"]
COPY ["EMailService/Services.EMail.Repositories/Services.EMail.Repositories.csproj", "EMailService/Services.EMail.Repositories/"]
COPY ["Shared/Services.Shared.Data/Services.Shared.Data.csproj", "Shared/Services.Shared.Data/"]
COPY ["EMailService/Services.EMail.Data/Services.EMail.Data.csproj", "EMailService/Services.EMail.Data/"]
COPY ["EMailService/Services.EMail.Model/Services.EMail.Model.csproj", "EMailService/Services.EMail.Model/"]
RUN dotnet restore "EMailService/Services.EMail.Api/Services.EMail.Api.csproj"
COPY . .
WORKDIR "/src/EMailService/Services.EMail.Api"
RUN dotnet build "Services.EMail.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.EMail.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.EMail.Api.dll"]