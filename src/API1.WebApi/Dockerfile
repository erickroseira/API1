FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API1.WebApi.csproj", "src/API1.WebApi/"]
RUN dotnet restore "src/API1.WebApi/API1.WebApi.csproj"
COPY . "src/API1.WebApi/"
WORKDIR "/src/src/API1.WebApi"
RUN dotnet build "API1.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API1.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API1.WebApi.dll"]