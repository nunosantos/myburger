#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGateway/BurgerBackend.GW/BurgerBackend.GW.csproj", "ApiGateway/BurgerBackend.GW/"]
COPY ["Services/Authentication/Authentication.csproj", "Services/Authentication/"]
RUN dotnet restore "ApiGateway/BurgerBackend.GW/BurgerBackend.GW.csproj"
COPY . .
WORKDIR "/src/ApiGateway/BurgerBackend.GW"
RUN dotnet build "BurgerBackend.GW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BurgerBackend.GW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BurgerBackend.GW.dll"]