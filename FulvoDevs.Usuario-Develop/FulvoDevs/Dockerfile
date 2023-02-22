#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM docker pull mcr.microsoft.com/dotnet/aspnet #AS build
WORKDIR /src
COPY ["FulvoDevs.csproj", "."]
RUN dotnet restore "./FulvoDevs.csproj"
COPY . .
WORKDIR "/src/."
#EXPOSE 80
RUN dotnet build "FulvoDevs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FulvoDevs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FulvoDevs.dll"]
