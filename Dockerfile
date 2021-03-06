FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 44308

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["API-Romanis-NetCore.csproj", "./"]
RUN dotnet restore "API-Romanis-NetCore.csproj"
COPY . .
RUN dotnet build "API-Romanis-NetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API-Romanis-NetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-Romanis-NetCore.dll"]