# Use the official .NET 7 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project file and restore any dependencies
COPY API/*.csproj ./API/
RUN dotnet restore API/API.csproj

# Copy the rest of the application code
COPY API/. ./API/

# Build the application
WORKDIR /app/API
RUN dotnet build --configuration Release --output /app/build

# Publish the application
RUN dotnet publish --configuration Release --output /app/publish

# Use the official .NET 7 runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "API.dll"]
