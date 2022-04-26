#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthenticationService/Services.Authentication.Api/Services.Authentication.Api.csproj", "AuthenticationService/Services.Authentication.Api/"]
COPY ["Shared/Services.Shared.Authentication/Services.Shared.Authentication.csproj", "Shared/Services.Shared.Authentication/"]
COPY ["Shared/Services.Shared.Models/Services.Shared.Models.csproj", "Shared/Services.Shared.Models/"]
COPY ["AuthenticationService/Services.Authentication.Data/Services.Authentication.Data.csproj", "AuthenticationService/Services.Authentication.Data/"]
COPY ["AuthenticationService/Services.Authentication.Model/Services.Authentication.Model.csproj", "AuthenticationService/Services.Authentication.Model/"]
RUN dotnet restore "AuthenticationService/Services.Authentication.Api/Services.Authentication.Api.csproj"
COPY . .
WORKDIR "/src/AuthenticationService/Services.Authentication.Api"
RUN dotnet build "Services.Authentication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Authentication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Authentication.Api.dll"]