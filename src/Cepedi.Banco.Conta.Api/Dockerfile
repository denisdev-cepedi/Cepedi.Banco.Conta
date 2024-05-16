FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Cepedi.Banco.Conta.Api/Cepedi.Banco.Conta.Api.csproj", "src/Cepedi.Banco.Conta.Api/"]
COPY ["src/Cepedi.Banco.Conta.IoC/Cepedi.Banco.Conta.IoC.csproj", "src/Cepedi.Banco.Conta.IoC/"]
COPY ["src/Cepedi.Banco.Conta.Dados/Cepedi.Banco.Conta.Dados.csproj", "src/Cepedi.Banco.Conta.Dados/"]
COPY ["src/Cepedi.Banco.Conta.Dominio/Cepedi.Banco.Conta.Dominio.csproj", "src/Cepedi.Banco.Conta.Dominio/"]
COPY ["src/Cepedi.Banco.Conta.Compartilhado/Cepedi.Banco.Conta.Compartilhado.csproj", "src/Cepedi.Banco.Conta.Compartilhado/"]
RUN dotnet restore "src/Cepedi.Banco.Conta.Api/Cepedi.Banco.Conta.Api.csproj"
COPY . .
WORKDIR "/src/src/Cepedi.Banco.Conta.Api"
RUN dotnet build "Cepedi.Banco.Conta.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Cepedi.Banco.Conta.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cepedi.Banco.Conta.Api.dll"]
