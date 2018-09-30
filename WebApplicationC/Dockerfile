FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59983
EXPOSE 44305

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApplicationC/WebApplicationC.csproj", "WebApplicationC/"]
RUN dotnet restore "WebApplicationC/WebApplicationC.csproj"
COPY . .
WORKDIR "/src/WebApplicationC"
RUN dotnet build "WebApplicationC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplicationC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplicationC.dll"]