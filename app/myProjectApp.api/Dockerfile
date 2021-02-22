#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["app/myProjectApp.api/myProjectApp.api.csproj", "app/myProjectApp.api/"]
RUN dotnet restore "app/myProjectApp.api/myProjectApp.api.csproj"
COPY . .
WORKDIR "/src/app/myProjectApp.api"
RUN dotnet build "myProjectApp.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "myProjectApp.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "myProjectApp.api.dll"]