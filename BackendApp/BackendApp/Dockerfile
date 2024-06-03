FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BackendApp.sln", "."]
COPY ["BackendApp/BackendApp.csproj", "BackendApp/"]
COPY ["BackendApp-Application/BackendApp-Application.csproj", "BackendApp-Application/"]
COPY ["BackendApp-Domain/BackendApp-Domain.csproj", "BackendApp-Domain/"]
COPY ["BackendApp-Infrastructure/BackendApp-Infrastructure.csproj", "BackendApp-Infrastructure/"]
RUN dotnet restore "BackendApp/BackendApp.csproj"
COPY . .
WORKDIR "/src/BackendApp"
RUN dotnet build "BackendApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY BackendApp/wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh
ENTRYPOINT ["/app/wait-for-it.sh", "sqlserver:1433", "--", "dotnet", "BackendApp.dll"]