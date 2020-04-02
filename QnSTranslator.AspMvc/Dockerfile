#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["QnSTranslator.AspMvc/QnSTranslator.AspMvc.csproj", "QnSTranslator.AspMvc/"]
COPY ["QnSTranslator.Adapters/QnSTranslator.Adapters.csproj", "QnSTranslator.Adapters/"]
COPY ["QnSTranslator.Logic/QnSTranslator.Logic.csproj", "QnSTranslator.Logic/"]
COPY ["QnSTranslator.Contracts/QnSTranslator.Contracts.csproj", "QnSTranslator.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["QnSTranslator.Transfer/QnSTranslator.Transfer.csproj", "QnSTranslator.Transfer/"]
RUN dotnet restore "QnSTranslator.AspMvc/QnSTranslator.AspMvc.csproj"
COPY . .
WORKDIR "/src/QnSTranslator.AspMvc"
RUN dotnet build "QnSTranslator.AspMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QnSTranslator.AspMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QnSTranslator.AspMvc.dll"]