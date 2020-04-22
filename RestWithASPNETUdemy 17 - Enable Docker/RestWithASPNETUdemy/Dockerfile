FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["RestWithASPNETUdemy/RestWithASPNETUdemy.csproj", "RestWithASPNETUdemy/"]
RUN dotnet restore "RestWithASPNETUdemy/RestWithASPNETUdemy.csproj"
COPY . .
WORKDIR "/src/RestWithASPNETUdemy"
RUN dotnet build "RestWithASPNETUdemy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestWithASPNETUdemy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestWithASPNETUdemy.dll"]
