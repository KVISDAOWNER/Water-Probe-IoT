FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Org.OpenAPITools/Org.OpenAPITools.csproj", "src/Org.OpenAPITools/"]
RUN dotnet restore "src/Org.OpenAPITools/Org.OpenAPITools.csproj"
COPY . .
WORKDIR "/src/src/Org.OpenAPITools"
RUN dotnet build "Org.OpenAPITools.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Org.OpenAPITools.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Org.OpenAPITools.dll"]