FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MicanoStore.Services.CouponAPI/MicanoStore.Services.CouponAPI.csproj", "MicanoStore.Services.CouponAPI/"]
RUN dotnet restore "MicanoStore.Services.CouponAPI/MicanoStore.Services.CouponAPI.csproj"
COPY . .
WORKDIR "/src/MicanoStore.Services.CouponAPI"
RUN dotnet build "MicanoStore.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MicanoStore.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicanoStore.Services.CouponAPI.dll"]
