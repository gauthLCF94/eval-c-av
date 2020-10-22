#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Venezia/Venezia.csproj", "Venezia/"]
RUN dotnet restore "Venezia/Venezia.csproj"
COPY . .
WORKDIR "/src/Venezia"
RUN dotnet build "Venezia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Venezia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Venezia.dll"]