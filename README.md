# GameLogs

Logan Nguyen, Raphaël Robert, Sven Raval

## API to get videogames later on
https://rawg.io/apidocs


## Versions et softwares

.NET version 6.0  
Visual Studio enterprise 2022 last version  
WinForm C#  

## Description du project 

GameLogs est un logiciel qui pourra être utilisé comme une "Game List" où l'on peut insérer les jeux vidéo qu'on a terminer mais aussi les jeux qu'on planifie à faire. Les utilisateurs pourrons aussi insérer une review du jeu et y mettre une note aux jeux. Il utilisera l' API rawg (bloqué par le CPNV) et une base de données qui syncronisera les données insérer.

## Getting Started

### Prerequesites
	*IDE : Visual Studio 2022
	*Package Manager : Nuget

### Configuration
[Installation Visual Studio 2022](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022)

## Deployement

### On Dev Environment

### Première compilation
Après avoir "clone" le dépôt sur la branche main, vous pouvez tenter une première compilation qui devrait vous donner ce résultat:

[INPUT]

Menu: Build->Build Solution

[OUTPUT]
```
3>Done building project "TestShopping.csproj".
========== Rebuild All: 3 succeeded, 0 failed, 0 skipped ==========
========== Rebuild started at 13:21 and took 00.747 seconds ==========
```
### Exécuter les tests

Pour afficher l'explorateur de test:
MENU : Test-> Test Explorer

[INPUT]

![image](https://github.com/CPNV-226a/Shopping/assets/5616312/4d05053e-f261-41a3-b445-f6d79bf80eb1)

[OUTPUT]

![image](https://github.com/CPNV-226a/Shopping/assets/5616312/182d2ce6-f4aa-465a-be9c-0215d458ee7c)

Vous obtenez tous les tests en échecs présentant le même message d'erreur:
"System.NotImplementedException:[...]"

Cela prouve que votre projet se compile et que les tests sont opérationnels.

## License
[License](main/license.txt)
