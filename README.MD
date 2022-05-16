<div align="center">
  <h1> RussianHub </h1>
</div>

## Description
**Russian hub** is similar to PornHub, but Russian. Unlike PornHub, our hub is open source and created for all comrades around the world. Let's provide every home with a high-quality porn service! Hurray!

## Motivation
MSTU STANKIN will hurt if it turns out poop

## How to work with project?

The project does not have hosting yet, so you can run the project on your local machine.
The startup algorithm is something like this (if you are working in the console):
```
git clone https://github.com/BioMihanoid/RussianHub
cd  RussianHub
add-migration -context VideoContest YourNameMigration
update-database -context VideoContext
add-migration -context ActorContext YourNameMigration
update-database -context ActorContext
add-migration -context CommentContest YourNameMigration
update-database -context CommentContest
dotnet run
```
Or you can open Visual Studio 2022, choose there that you want to work with the project from github, insert this link there https://github.com/BioMihanoid/RussianHub , apply the following migrations to the package manager console and run the project.
```
add-migration -context VideoContest YourNameMigration
update-database -context VideoContext
add-migration -context ActorContext YourNameMigration
update-database -context ActorContext
add-migration -context CommentContest YourNameMigration
update-database -context CommentContest
```

## Technologies in this project
* C# 6.0
* ASP.NET MVC 5
* Entity Framework 6
* HTML5
* CSS3
* JS

## Project plans

update required

## Authors
* **Mikhail Pechnikov** - *Backend* - [BioMihanoid](https://github.com/BioMihanoid)
* **Oleg Malygin** - *Frontend* - [gh0stman447](https://github.com/gh0stman447)
* **Andrey Klets** - *Backend* - [Andrei6115](https://github.com/Andrei6115)
