FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

ARG CONFIG=RELEASE
ARG VERSAO=1.0.0

WORKDIR /build

COPY taxaJuros.sln .
COPY ./TaxaJuros.Api/*.csproj ./TaxaJuros.Api/
COPY ./TaxaJuros.Core/*.csproj ./TaxaJuros.Core/
COPY ./TaxaJuros.Tests/*.csproj ./TaxaJuros.Tests/
RUN dotnet restore

COPY ./TaxaJuros.Api/. ./TaxaJuros.Api/
COPY ./TaxaJuros.Core/. ./TaxaJuros.Core/
COPY ./TaxaJuros.Tests/. ./TaxaJuros.Tests/
RUN dotnet publish -c ${CONFIG} -o out /p:Version=${VERSAO}

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80

COPY --from=build /build/out/. ./

ENTRYPOINT ["dotnet", "TaxaJuros.Api.dll"]