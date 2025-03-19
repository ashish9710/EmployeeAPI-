 # Use the official .NET SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the solution and all project files
COPY MyDotNetAPI.sln ./
COPY EmployeeAPI/*.csproj EmployeeAPI/
COPY MyAPI/*.csproj MyAPI/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application code and build the project
COPY EmployeeAPI/. EmployeeAPI/
COPY MyAPI/. MyAPI/

# Set the working directory for EmployeeAPI
WORKDIR /app/EmployeeAPI
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expose the application port
EXPOSE 5000

# Set the entry point for the container
CMD ["dotnet", "EmployeeAPI.dll"]

