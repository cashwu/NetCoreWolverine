FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ponger/Ponger.csproj", "Ponger/"]
RUN dotnet restore "Ponger/Ponger.csproj"
COPY . .
WORKDIR "/src/Ponger"
RUN dotnet build "Ponger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ponger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ponger.dll"]
