#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AM.Deployment/AM.Deployment.csproj", "AM.Deployment/"]
RUN dotnet restore "AM.Deployment/AM.Deployment.csproj"
COPY . .
WORKDIR "/src/AM.Deployment"
RUN dotnet build "AM.Deployment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AM.Deployment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AM.Deployment.dll"]