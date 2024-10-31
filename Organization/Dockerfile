# Use the ASP.NET runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["Organization/Organization.csproj", "Organization/"]
RUN dotnet restore "Organization/Organization.csproj"

# Copy the entire project and build it
COPY . .
WORKDIR /src/Organization
RUN dotnet build "Organization.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Organization.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish -p:UseAppHost=false

# Final stage: Use the runtime image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Organization.dll"]
