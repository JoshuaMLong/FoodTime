#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FoodTime/FoodTime.API.csproj", "FoodTime/"]
COPY ["FoodTime.Domain/FoodTime.Domain.csproj", "FoodTime.Domain/"]
COPY ["FoodTime.Infrastructure/FoodTime.Infrastructure.csproj", "FoodTime.Infrastructure/"]
RUN dotnet restore "FoodTime/FoodTime.API.csproj"
COPY . .
WORKDIR "/src/FoodTime"
RUN dotnet build "FoodTime.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodTime.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodTime.API.dll"]