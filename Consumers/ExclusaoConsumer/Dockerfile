# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Optionally, add USER app if you have a non-root user set up
# RUN adduser -D app
# USER app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Consumers/ExclusaoConsumer/ExclusaoConsumer.csproj", "Consumers/ExclusaoConsumer/"]
RUN dotnet restore "Consumers/ExclusaoConsumer/ExclusaoConsumer.csproj"
COPY . .
WORKDIR "/src/Consumers/ExclusaoConsumer"
RUN dotnet build "ExclusaoConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "./ExclusaoConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExclusaoConsumer.dll"]