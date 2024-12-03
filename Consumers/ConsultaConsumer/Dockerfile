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
COPY ["Consumers/ConsultaConsumer/ConsultaConsumer.csproj", "Consumers/ConsultaConsumer/"]
RUN dotnet restore "Consumers/ConsultaConsumer/ConsultaConsumer.csproj"
COPY . .
WORKDIR "/src/Consumers/ConsultaConsumer"
RUN dotnet build "ConsultaConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "./ConsultaConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsultaConsumer.dll"]