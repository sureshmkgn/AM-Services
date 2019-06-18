FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY ./bin/Release/netcoreapp2.2/publish .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5000
ENTRYPOINT dotnet FA.Services.Identity.dll