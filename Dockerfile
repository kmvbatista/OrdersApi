FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiEntryPoint/ApiEntryPoint.csproj", "ApiEntryPoint/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "ApiEntryPoint/ApiEntryPoint.csproj"
COPY . .
WORKDIR "/src/ApiEntryPoint"
RUN dotnet build "ApiEntryPoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiEntryPoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiEntryPoint.dll"]
