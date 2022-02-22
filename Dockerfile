FROM microsoft/dotnet:5.0-sdk AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore PrivateNotes.csproj
COPY . ./
RUN dotnet publish PrivateNotes.csproj -c Release -o out
FROM microsoft/dotnet:5.0-aspnetcore-runtime AS runtime
WORKDIR /app
COPY — from=build /app/out .
ENTRYPOINT [“dotnet”, “PrivateNotes.dll”]`