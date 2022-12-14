#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Restaurant/src/Restaurant.API/Restaurant.API.csproj", "Services/Restaurant/src/Restaurant.API/"]
COPY ["Services/Restaurant/src/Restaurant.Infrastructure/Restaurant.Infrastructure.csproj", "Services/Restaurant/src/Restaurant.Infrastructure/"]
COPY ["Services/Restaurant/src/Restaurant.Application/Restaurant.Application.csproj", "Services/Restaurant/src/Restaurant.Application/"]
COPY ["Services/Restaurant/src/Restaurant.Domain/Restaurant.Domain.csproj", "Services/Restaurant/src/Restaurant.Domain/"]
COPY ["Utilities/BurgerBackend.Common/BurgerBackend.Common.csproj", "Utilities/BurgerBackend.Common/"]
RUN dotnet restore "Services/Restaurant/src/Restaurant.API/Restaurant.API.csproj"
COPY . .
WORKDIR "/src/Services/Restaurant/src/Restaurant.API"
RUN dotnet build "Restaurant.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.API.dll"]