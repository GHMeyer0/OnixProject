#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Template.Api/OnixProject.Api.csproj", "src/Template.Api/"]
RUN dotnet restore "src/Template.Api/OnixProject.Api.csproj"
COPY . .
WORKDIR "/src/src/Template.Api"
RUN dotnet build "OnixProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnixProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnixProject.Api.dll"]
