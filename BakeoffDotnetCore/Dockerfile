FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../BakeoffDotnetCore.csproj", "BakeoffDotnetCore/"]
RUN dotnet restore "BakeoffDotnetCore/BakeoffDotnetCore.csproj"
COPY . ./BakeoffDotnetCore
WORKDIR "/src/BakeoffDotnetCore"
RUN dotnet build "BakeoffDotnetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BakeoffDotnetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BakeoffDotnetCore.dll"]
