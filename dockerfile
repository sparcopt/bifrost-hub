ARG DOTNET_SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:6.0
ARG DOTNET_RUNTIME_IMAGE=mcr.microsoft.com/dotnet/aspnet:6.0

FROM ${DOTNET_SDK_IMAGE} AS build-env
ARG RELEASE_VERSION
WORKDIR /app

COPY BifrostHub.sln BifrostHub.sln
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

RUN dotnet restore BifrostHub.sln --no-cache
COPY . .
RUN dotnet build --no-restore --configuration Release BifrostHub.sln -p:Version=$RELEASE_VERSION

WORKDIR /app/src/Web.Application
RUN dotnet publish "Web.Application.csproj" -c Release --no-build --no-restore -o /app/publish -p:Version=$RELEASE_VERSION

FROM ${DOTNET_RUNTIME_IMAGE}
WORKDIR /app
COPY --from=build-env /app/publish .
ENV ASPNETCORE_URLS=http://+:5134
EXPOSE 5134
ENTRYPOINT ["dotnet", "Web.Application.dll"]