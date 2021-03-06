#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 6355
EXPOSE 44389

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Service.Api/Service.Api.csproj", "Service.Api/"]
RUN dotnet restore "Service.Api/Service.Api.csproj"
COPY . .
WORKDIR "/src/Service.Api"
RUN dotnet build "Service.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Service.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Service.Api.dll"]