# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Auroque.Api/Auroque.Api.csproj", "Auroque.Api/"]
COPY ["Auroque.Application/Auroque.Application.csproj", "Auroque.Application/"]
COPY ["Auroque.Domain/Auroque.Domain.csproj", "Auroque.Domain/"]
COPY ["Auroque.Infrastructure/Auroque.Infrastructure.csproj", "Auroque.Infrastructure/"]
RUN dotnet restore "Auroque.Api/Auroque.Api.csproj"
COPY . .
WORKDIR "/src/Auroque.Api"
RUN dotnet build "Auroque.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auroque.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auroque.Api.dll"]
