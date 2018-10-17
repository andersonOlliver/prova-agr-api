FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/CN.Taverna.API/CN.Taverna.API.csproj src/CN.Taverna.API/
RUN dotnet restore src/CN.Taverna.API/CN.Taverna.API.csproj
COPY . .
WORKDIR /src/src/CN.Taverna.API
RUN dotnet build CN.Taverna.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CN.Taverna.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CN.Taverna.API.dll"]
