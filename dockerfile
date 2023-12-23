﻿ARG DOTNET_SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-arm64v8
ARG DOTNET_RUNTIME_IMAGE=mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-arm64v8

FROM ${DOTNET_SDK_IMAGE} AS build-env
ARG RELEASE_VERSION
WORKDIR /app
COPY . .
RUN dotnet restore BifrostHub.sln --no-cache
RUN dotnet build --no-restore --configuration Release BifrostHub.sln -p:Version=$RELEASE_VERSION

WORKDIR /app/src/Web.Application
RUN dotnet publish "Web.Application.csproj" -c Release --no-build --no-restore -o /app/publish -p:Version=$RELEASE_VERSION

FROM ${DOTNET_RUNTIME_IMAGE}
WORKDIR /app
COPY --from=build-env /app/publish .
ENV ASPNETCORE_URLS=http://+:5134 \
    ASPNETCORE_ENVIRONMENT=Docker
EXPOSE 5134
ENTRYPOINT ["dotnet", "Web.Application.dll"]