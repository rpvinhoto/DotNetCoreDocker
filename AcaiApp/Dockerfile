FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY ["Acai.Api/Acai.Api.csproj", "Acai.Api/"]
COPY ["Acai.Application/Acai.Application.csproj", "Acai.Application/"]
COPY ["Acai.Domain/Acai.Domain.csproj", "Acai.Domain/"]
COPY ["Acai.Infra/Acai.Infra.csproj", "Acai.Infra/"]
RUN dotnet restore "Acai.Api/Acai.Api.csproj"
COPY . .
WORKDIR "/src/Acai.Api"
RUN dotnet build "Acai.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acai.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acai.Api.dll"]