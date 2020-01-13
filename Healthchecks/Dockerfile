#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Healthchecks/Healthchecks.csproj", "Healthchecks/"]
RUN dotnet restore "Healthchecks/Healthchecks.csproj"
COPY . .
WORKDIR "/src/Healthchecks"
RUN dotnet build "Healthchecks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Healthchecks.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthchecks.dll"]