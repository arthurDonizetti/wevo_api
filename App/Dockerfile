FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /usr/src/app

ENV DOCKERIZE_VERSION v0.6.1
RUN wget https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
  && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
  && rm dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz

COPY . .

RUN dotnet tool install --global dotnet-ef --version 5.0.2

ENV PATH="$PATH:/root/.dotnet/tools"

# RUN cd ./Infra \
#   && dotnet ef database update --context FileStorageContext \
#   && dotnet ef database update --context ApiContext

RUN  dotnet restore \
  && dotnet build

ENTRYPOINT [ "dotnet", "run", "-p", "./Api" ]

CMD ["bash"]
