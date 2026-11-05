FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "HospitalSystem.Presentation/HospitalSystem.Presentation.csproj"
WORKDIR "/src/HospitalSystem.Presentation"
RUN dotnet build "HospitalSystem.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HospitalSystem.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HospitalSystem.Presentation.dll"]