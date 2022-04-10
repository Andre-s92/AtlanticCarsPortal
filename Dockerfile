#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AtlanticCarsPortal.API/AtlanticCarsPortal.API.csproj", "AtlanticCarsPortal.API/"]
COPY ["AtlanticCarsPortal.Application/AtlanticCarsPortal.Application.csproj", "AtlanticCarsPortal.Application/"]
COPY ["AtlanticCarsPortal.Domain/AtlanticCarsPortal.Domain.csproj", "AtlanticCarsPortal.Domain/"]
COPY ["AtlanticCarsPortal.Data/AtlanticCarsPortal.Data.csproj", "AtlanticCarsPortal.Data/"]
RUN dotnet restore "AtlanticCarsPortal.API/AtlanticCarsPortal.API.csproj"
COPY . .
WORKDIR "/src/AtlanticCarsPortal.API"
RUN dotnet build "AtlanticCarsPortal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AtlanticCarsPortal.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT="Development"
#padrão dotnet
#ENTRYPOINT ["dotnet", "AtlanticCarsPortal.API.dll","--environment=Development"]
#padrão Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AtlanticCarsPortal.API.dll