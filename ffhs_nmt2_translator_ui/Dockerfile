FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ffhs_nmt2_translator_ui.csproj", "ffhs_nmt2_translator_ui/"]
RUN dotnet restore "ffhs_nmt2_translator_ui/ffhs_nmt2_translator_ui.csproj"
WORKDIR "/src/ffhs_nmt2_translator_ui"
COPY . .
RUN dotnet build "ffhs_nmt2_translator_ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ffhs_nmt2_translator_ui.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ffhs_nmt2_translator_ui.dll"]