FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/EduPlanner.API/EduPlanner.API.csproj", "EduPlanner.API/"]
COPY ["src/EduPlanner.Application/EduPlanner.Application.csproj", "EduPlanner.Application/"]
COPY ["src/EduPlanner.Domain/EduPlanner.Domain.csproj", "EduPlanner.Domain/"]
COPY ["src/EduPlanner.Infrastructure/EduPlanner.Infrastructure.csproj", "EduPlanner.Infrastructure/"]

RUN dotnet restore "EduPlanner.API/EduPlanner.API.csproj"
COPY . ../
WORKDIR /src/EduPlanner.API
RUN dotnet build "EduPlanner.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduPlanner.API.dll"]