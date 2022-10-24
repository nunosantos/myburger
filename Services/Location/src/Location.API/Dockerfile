#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Location/src/Location.API/User.API.csproj", "Services/Location/src/Location.API/"]
COPY ["Services/Location/src/Location.Application/User.Application.csproj", "Services/Location/src/Location.Application/"]
COPY ["Utilities/BurgerBackend.Common/BurgerBackend.Common.csproj", "Utilities/BurgerBackend.Common/"]
RUN dotnet restore "Services/Location/src/Location.API/User.API.csproj"
COPY . .
WORKDIR "/src/Services/Location/src/Location.API"
RUN dotnet build "User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]