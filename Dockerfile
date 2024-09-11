# Use the .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /

# Copy the solution file and project files
COPY api_rapid.sln ./
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore api_rapid.sln

# Copy the rest of the code
COPY . .

# Build the application
RUN dotnet build --configuration Release api_rapid.sln

# Publish the application
RUN dotnet publish --configuration Release --output /app/publish api_rapid.sln

# Use the .NET 8.0 runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "GamingAPI.dll"]