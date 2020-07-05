FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

ARG CONFIG=RELEASE
ARG VERSAO=1.0.0

WORKDIR /build

COPY calculaJuros.sln .
COPY ./CalculaJuros.Api/*.csproj ./CalculaJuros.Api/
COPY ./CalculaJuros.Core/*.csproj ./CalculaJuros.Core/
COPY ./CalculaJuros.Tests/*.csproj ./CalculaJuros.Tests/
RUN dotnet restore

COPY ./CalculaJuros.Api/. ./CalculaJuros.Api/
COPY ./CalculaJuros.Core/. ./CalculaJuros.Core/
COPY ./CalculaJuros.Tests/. ./CalculaJuros.Tests/
RUN dotnet publish -c ${CONFIG} -o out /p:Version=${VERSAO}

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80

COPY --from=build /build/out/. ./

ENTRYPOINT ["dotnet", "CalculaJuros.Api.dll"]