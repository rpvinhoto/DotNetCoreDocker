FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Build image runtime!
FROM microsoft/dotnet:aspnetcore-runtime
MAINTAINER renatoodt@hotmail.com
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Acai.Api.dll"]