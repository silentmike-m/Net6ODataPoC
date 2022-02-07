FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY Net6ODataPoc.sln Net6ODataPoc.sln
COPY Net6ODataPoc.Application/Net6ODataPoc.Application.csproj Net6ODataPoc.Application/Net6ODataPoc.Application.csproj
COPY Net6ODataPoc.Domain/Net6ODataPoc.Domain.csproj Net6ODataPoc.Domain/Net6ODataPoc.Domain.csproj
COPY Net6ODataPoc.Infrastructure/Net6ODataPoc.Infrastructure.csproj Net6ODataPoc.Infrastructure/Net6ODataPoc.Infrastructure.csproj
COPY Net6ODataPoc.WebApi/Net6ODataPoc.WebApi.csproj Net6ODataPoc.WebApi/Net6ODataPoc.WebApi.csproj
RUN dotnet restore

COPY . .

RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

RUN apt-get update && apt-get install -y curl=7.74.0-1.3+deb11u1 --no-install-recommends && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

RUN groupadd -g 10000 dotnet && useradd -u 10000 -g dotnet dotnet && chown -R dotnet:dotnet /app
USER dotnet:dotnet

ENV ASPNETCORE_URLS http://*:5080
EXPOSE 5080

HEALTHCHECK --interval=5s --timeout=10s --retries=3 CMD curl --fail http://localhost:5080/health || exit 1

ENTRYPOINT ["dotnet", "Net6ODataPoc.WebApi.dll"]
