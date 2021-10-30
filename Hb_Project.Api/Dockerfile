#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hb_Project.Api/Hb_Project.Api.csproj", "Hb_Project.Api/"]
COPY ["Hb_Project.Application/Hb_Project.Application.csproj", "Hb_Project.Application/"]
COPY ["Hb_Project.Infrastructure/Hb_Project.Infrastructure.csproj", "Hb_Project.Infrastructure/"]
COPY ["Hb_Project.Domain/Hb_Project.Domain.csproj", "Hb_Project.Domain/"]
RUN dotnet restore "Hb_Project.Api/Hb_Project.Api.csproj"
COPY . .
WORKDIR "/src/Hb_Project.Api"
RUN dotnet build "Hb_Project.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hb_Project.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hb_Project.Api.dll"]