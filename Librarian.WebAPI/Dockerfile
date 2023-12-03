#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Librarian.WebAPI/Librarian.WebAPI.csproj", "Librarian.WebAPI/"]
COPY ["LibrarianApplication/Librarian.Application.csproj", "LibrarianApplication/"]
COPY ["Librarian.Infra/Librarian.Infrastructure.csproj", "Librarian.Infra/"]
COPY ["LibrarianDomain/Librarian.Domain.csproj", "LibrarianDomain/"]
RUN dotnet restore "./Librarian.WebAPI/./Librarian.WebAPI.csproj"
COPY . .
WORKDIR "/src/Librarian.WebAPI"
RUN dotnet build "./Librarian.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Librarian.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Librarian.WebAPI.dll"]