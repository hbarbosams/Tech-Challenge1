#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Application/Application.csproj", "Application/"]
COPY ["CrossCutting/CrossCutting.csproj", "CrossCutting/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "./Application/Application.csproj"
COPY . .
WORKDIR "/src/Application"
RUN dotnet build "./Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]