FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update \
	&& apt-get install -y curl \
	&& apt-get install -y vim \
	&& apt-get clean
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HealthcheckTest/HealthcheckTest.csproj", "HealthcheckTest/"]
RUN dotnet restore "HealthcheckTest/HealthcheckTest.csproj"
COPY . .
WORKDIR "/src/HealthcheckTest"
RUN dotnet build "HealthcheckTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthcheckTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
HEALTHCHECK --interval=30s --timeout=3s --start-period=30s --retries=3 \
	CMD exit $(curl -f -L 127.0.0.1:80 || 1)
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthcheckTest.dll"]
