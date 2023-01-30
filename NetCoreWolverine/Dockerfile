FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NetCoreWolverine/NetCoreWolverine.csproj", "NetCoreWolverine/"]
RUN dotnet restore "NetCoreWolverine/NetCoreWolverine.csproj"
COPY . .
WORKDIR "/src/NetCoreWolverine"
RUN dotnet build "NetCoreWolverine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreWolverine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreWolverine.dll"]
