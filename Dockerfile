# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /productservice

# copy csproj and restore as distinct layers
# COPY *.sln .
COPY . .
RUN dotnet restore productservice.csproj

# copy everything else and build app
WORKDIR /productservice
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "productservice.dll"]