# Recipe manager API

This api will be used by my frontend [Frontend](https://github.com/tobinstultiens/Recipe-manager-presentation).

## Getting Started
By following these instructions you will be able to run this project for development purposes.

### Prerequisites
You will need the following tools installed:

* [Visual Studio 2019 or Rider 2019](https://visualstudio.microsoft.com/vs/)
* [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Docker](https://docs.docker.com/get-docker/)
* [Dotnet tool](#dotnettool)
* [Postgres](https://hub.docker.com/_/postgres)

#### <a name="dotnettool"></a>Installing dotnet tool

Using the following command you can install dotnet tool globally on the latest version. This is neccesary for the migration aspect for the database.

`dotnet tool install -g dotnet-ef`

### Setup
1. Clone the repository
2. Change the `appsettings.json` file at the root of the RecipeManagerApi project with your postgresconnection to your database. It is reccomended to run this database in docker.
3. Use `dotnet restore` followed by `dotnet build`.

## Install and Usage

This command will run the recipemanager api on the 5000 and 5001 port. Also to make use of the docker postgres database we need to connect it to a network which in this sample is called `test_network`.

`docker run -d -p 127.0.0.1:5000:443 -p 127.0.0.1:5001:80 --network test_network -e ConnectionStrings__PostgresConnectionString="Host=;Port=;Database=;Username=;Password=;" recipemanagerapi:latest`

This command is to setup the postgres database.

`docker run --name pg-docker -e POSTGRES_PASSWORD=docker -d -p 127.0.0.1:5432:5432 -v $HOME/docker/volumes/postgres:/var/lib/postgresql/data postgres:11.7`
