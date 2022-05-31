# RussianHub

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
update-database
dotnet run
```
Or you can open Visual Studio 2022/Rider, choose there that you want to work with the project from github, insert this link there https://github.com/BioMihanoid/RussianHub , apply the following migrations to the package manager console and run the project.
```
update-database
```

P.S. I didn't write about migration for the user above, but when you create the page itself will offer to apply it, agree and then everything will work for you. In order to fully enjoy the work of the site, you need to register a user and log in to his account. After you log in, you will have access to the admin panel, where you can fill the site with content and see its functionality after.

P.P.S. You must have MS(SQL Server Management Studio) installed. Follow the link below to see how to do it and where to download it.
https://docs.microsoft.com/ru-ru/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15

## Technologies in this project
* C# 6.0
* ASP.NET MVC 5
* Entity Framework 6
* HTML5
* CSS3
* JS

## Project plans

- [X] ~~Add comments to the video (from the user or from the guest)~~
- [X] ~~Add age verification at registration~~
- [ ] Add confirmation by email account
- [ ] Make an admin panel only for admins
- [ ] Add a rating
- [ ] Add country ~~and gender~~ to models
- [ ] Make a section with a blog
- [X] ~~Make a section with gifs~~
- [X] ~~Make a table with photos~~
- [ ] Make a feedback form
- [ ] Add all sorts of videos by rating and dates
- [ ] Write all sorts of models

## Authors
* **Mikhail Pechnikov** - *Backend* - [BioMihanoid](https://github.com/BioMihanoid)
* **Oleg Malygin** - *Frontend* - [gh0stman447](https://github.com/gh0stman447)
* **Andrey Klets** - *Backend* - [Andrei6115](https://github.com/Andrei6115)
