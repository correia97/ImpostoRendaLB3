FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 as build-env
WORKDIR /app

# Copiar os arquivos da solution para o container
COPY  . ./
# Executa o restore
RUN dotnet restore
# Executa os teste
RUN dotnet test

# Publica a Aplicação
RUN dotnet publish -c Release -o out



# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.6-alpine3.9
WORKDIR /app
COPY --from=build-env /app/src/API/ImpostoRendaLB3.API/out .
ENTRYPOINT [ "dotnet","ImpostoRendaLB3.API.dll" ]
