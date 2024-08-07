FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyFinances.Api/MyFinances.Api.csproj", "MyFinances.Api/"]
COPY ["MyFinances.Application/MyFinances.Application.csproj", "MyFinances.Application/"]
COPY ["MyFinances.DAL/MyFinances.DAL.csproj", "MyFinances.DAL/"]
COPY ["MyFinances.Domain/MyFinances.Domain.csproj", "MyFinances.Domain/"]
RUN dotnet restore "./MyFinances.Api/MyFinances.Api.csproj"
COPY . .
WORKDIR "/src/MyFinances.Api"
RUN dotnet build "./MyFinances.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyFinances.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFinances.Api.dll"]