FROM microsoft/aspnetcore:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY *.sln ./
COPY ../CatalogAPI/CatalogAPI.csproj ../CatalogAPI/
RUN dotnet restore
COPY . .
WORKDIR /src/../CatalogAPI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CatalogAPI.dll"]
