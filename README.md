# BookStore.DockerCompose
### Full stack PC pet-project of the online sopping "BookStore" includes: Backend-Asp.Net Core; Client-React.js; Proxy Server-Nginx; Docker and Docker Compose with Linux containers.
### BookStore.Client-docker image deployed on Dockerhub 
https://hub.docker.com/r/dockerhubdockerid2022/bookstore_client_for_use_proxy
### Data Base deployed on host somee.com
### Developed in Visual Studio 2022/Docker Desktop 4.19.0
___
### Stack:
* .Net Core Web API
* Entity Framework Core
* React.js
* Redux
* Docker
* Docker Compose
* Nginx
* PowerShell
___
### Database initialization 
1. Using Entity Framework Core solution with approach Code-First.
This database is being created when the project is first run.
The *DbInitializer.cs* file from the directory BookStore.Server.DAL/Data/ is used to initialize this database.
2. To create a database, you can use the *BookStoreScript.sql* file from the repo [BookStore.SqlScript](https://github.com/GoldinAlexander/BookStore.SqlScript.git)
____________________
### File docker-compose.yml 
![docker_compose_v1](https://github.com/AlexandrGoldin/BookStore.DockerCompose/assets/50864552/48e86e9b-6548-48ed-9ab0-2c5db2cc453b)
___________________________
### File nginx.conf 
![file nginx conf](https://github.com/AlexandrGoldin/BookStore.DockerCompose/assets/50864552/35caa2b5-1a54-42d0-8373-6d1133f64ad2)
