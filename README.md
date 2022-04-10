# AtlanticCarsPortal
Welcome to my project, follow steps to application works rightly

## To works remotely
You just need open the link https://atlanticcarsportal.herokuapp.com/swagger/index.html

## To works locally in IDE
1. Download the project 
2. In the directory of the project open console and put the code
```
dotnet ef database update -s AtlanticCarsPortal.API
```
3. Open the Visual Studio or VSCode as your choose
4. Execute the project

## To works on Docker
1. Download the project 
2. Create free database on https://www.db4free.net/
3. change ConnectionStrings in the file ```appsettings.Development.json``` 
4. In the directory of the project open console and put the code
```
dotnet ef database update -s AtlanticCarsPortal.API
```
5. put the code to create docker image in the console
```
 docker build -t atlanticcarsportal .
```
6. put the code to create docker container in the console
```
 docker run -d -p 5000:80 --name atlanticcarsportal atlanticcarsportal
```
7. Open the browser and put the link http://localhost:5000/swagger/index.html

------------------------------------------------------------------------------------------------------------

## Cars type legends

* 1 - Basic
* 2 - Economic
* 3 - Turbo
------------------------------------------------------------------------------------------------------------

## Functions of the project
* ```/Cars```
 -> List all existing cars in the database
 
* ```/Cars/CarsByType```
 -> List all existing cars in the database with the chosen type
 
* ```/Cars/{id}```
 -> List a car with the ID code provided
 
* ```/Cars/Distance/{distance}```
 -> Lists the car that will cover the given distance the fastest
 
* ```/Cars/BetterAutonomy```
 -> List the car with the best autonomy
 
 * ```/Cars/Refuel```
 -> Fill up the car with the informed id with the informed amount of gasoline in liters
 
  * ```/Cars/ActvateNewType```
 -> Change the type of car with the id informed and the type informed, see the types of existing lists in the **Functions of the project**
 
 --------------------------------------------------------------------------------------------------------------
 ## app features
 * Dotnet 6
 * Decorator Pattern
 * EntityFrameworkCore
 * MySQL
 * Swagger
 * AutoMapper
 * Unity Test(xUnit) 
 * Docker
