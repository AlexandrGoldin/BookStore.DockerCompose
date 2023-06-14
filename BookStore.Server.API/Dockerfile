#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BookStore.Server.API/BookStore.Server.API.csproj", "BookStore.Server.API/"]
COPY ["BookStore.Server.BLLServices/BookStore.Server.BLLServices.csproj", "BookStore.Server.BLLServices/"]
COPY ["BookStore.Server.BLL/BookStore.Server.BLL.csproj", "BookStore.Server.BLL/"]
COPY ["BookStore.Server.DAL/BookStore.Server.DAL.csproj", "BookStore.Server.DAL/"]
COPY ["BookStore.Server.Infrastructure/BookStore.Server.Infrastructure.csproj", "BookStore.Server.Infrastructure/"]
RUN dotnet restore "BookStore.Server.API/BookStore.Server.API.csproj"
COPY . .
WORKDIR "/src/BookStore.Server.API"
RUN dotnet build "BookStore.Server.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStore.Server.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.Server.API.dll"]