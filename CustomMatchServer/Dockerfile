FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY BapCustomServer.csproj ./
RUN dotnet restore BapCustomServer.csproj

COPY . ./
RUN dotnet publish BapCustomServer.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:5055
EXPOSE 5055

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "BapCustomServer.dll"]
