# Test ASP.NET Core

## Installation
- Installer Visual Studio
- Cloner le repo
- Ouvrir le fichier appsettings.json et changer la valeur de "DefaultConnection" par votre chaine de connection SQL Server
	> "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ZefixDB;Trusted_Connection=True;MultipleActiveResultSets=True" 
- Une fois la solution lancée, restaurer les packages et dépendances du projet, dans la console package manager avec la commande :
	> dotnet restore
- Pour génerer la base de données, executer la commande :
	> update-database
- Lancer
- Tester les APIs avec Swagger
