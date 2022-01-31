#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ReportService/ReportService.API/ReportService.API.csproj", "Services/ReportService/ReportService.API/"]
COPY ["BuildingBlocks/EventBus/EventBus.Factory/EventBus.Factory.csproj", "BuildingBlocks/EventBus/EventBus.Factory/"]
COPY ["BuildingBlocks/EventBus/EventBus.Base/EventBus.Base.csproj", "BuildingBlocks/EventBus/EventBus.Base/"]
COPY ["BuildingBlocks/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "BuildingBlocks/EventBus/EventBus.RabbitMQ/"]
COPY ["Shared/ContactsOnContainers.Shared/ContactsOnContainers.Shared.csproj", "Shared/ContactsOnContainers.Shared/"]
RUN dotnet restore "Services/ReportService/ReportService.API/ReportService.API.csproj"
COPY . .
WORKDIR "/src/Services/ReportService/ReportService.API"
RUN dotnet build "ReportService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportService.API.dll"]