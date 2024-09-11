# Use the .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and project files
COPY GamingAPI/api_rapid.sln ./
COPY GamingAPI/GamingAPI.csproj ./GamingAPI/

# Restore dependencies
RUN dotnet restore api_rapid.sln

# Copy the rest of the code
COPY GamingAPI/. ./GamingAPI/

# Build the application
RUN dotnet build --configuration Release api_rapid.sln

# Publish the application
RUN dotnet publish --configuration Release --output /app/publish GamingAPI/GamingAPI.csproj

# Use the .NET 8.0 runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "GamingAPI.dll"]
