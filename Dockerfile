FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore PrivateNotes.csproj
COPY . ./
RUN dotnet publish PrivateNotes.csproj -c Release -o out
ENTRYPOINT [“dotnet”, “PrivateNotes.dll”]`