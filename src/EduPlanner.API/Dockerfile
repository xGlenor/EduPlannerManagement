FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EduPlanner.API/EduPlanner.API.csproj", "src/EduPlanner.API/"]
COPY ["src/EduPlanner.Application/EduPlanner.Application.csproj", "src/EduPlanner.Application/"]
COPY ["src/EduPlanner.Domain/EduPlanner.Domain.csproj", "src/EduPlanner.Domain/"]
COPY ["src/EduPlanner.Infrastructure/EduPlanner.Infrastructure.csproj", "src/EduPlanner.Infrastructure/"]
RUN dotnet restore "src/EduPlanner.API/EduPlanner.API.csproj"
COPY . .
WORKDIR "/src/src/EduPlanner.API"
RUN dotnet build "./EduPlanner.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EduPlanner.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduPlanner.API.dll"]
