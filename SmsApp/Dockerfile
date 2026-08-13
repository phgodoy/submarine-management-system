FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /src

# Project files
COPY ["Sms.WebApi/Sms.WebApi.csproj", "Sms.WebApi/"]
COPY ["Sms.Infra.Ioc/Sms.Infra.Ioc.csproj", "Sms.Infra.Ioc/"]
COPY ["Sms.Infra.Data/Sms.Infra.Data.csproj", "Sms.Infra.Data/"]
COPY ["Sms.Application/Sms.Application.csproj", "Sms.Application/"]
COPY ["Sms.Domain/Sms.Domain.csproj", "Sms.Domain/"]

# Restore
RUN dotnet restore "Sms.WebApi/Sms.WebApi.csproj"

# Source
COPY . .

# Publish
RUN dotnet publish "Sms.WebApi/Sms.WebApi.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final

RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Sms.WebApi.dll"]