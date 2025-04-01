# ClubSportif Backend API

Ce projet constitue le backend d'une application de gestion de club sportif. Il est développé en **ASP.NET Core** et suit une architecture multicouche afin d'assurer une séparation claire des responsabilités, faciliter la maintenance et permettre une évolution agile de l'application.

## Table des Matières

- [Aperçu du Projet](#aperçu-du-projet)
- [Architecture](#architecture)
- [Prérequis](#prérequis)
- [Structure de la Solution](#structure-de-la-solution)
- [Configuration](#configuration)
- [Installation et Exécution](#installation-et-exécution)
- [Endpoints Principaux](#endpoints-principaux)
- [Migrations et Base de Données](#migrations-et-base-de-données)
- [Sécurité et Authentification](#sécurité-et-authentification)
- [Contributions](#contributions)
- [Licence](#licence)

## Aperçu du Projet

Le backend de **ClubSportif** fournit les API REST nécessaires à la gestion du club sportif. Les principales fonctionnalités incluent :

- **Gestion des utilisateurs** : joueurs, coachs et administrateurs.
- **Gestion des clubs, sections et catégories**.
- **Suivi des disponibilités et des présences**.
- **Gestion des matchs, tournois et convocations**.
- **Authentification** : login, inscription et génération de tokens JWT.

## Architecture

Le projet suit une architecture multicouche, organisée en plusieurs projets :

- **ClubSportif.Domain**  
  Contient les entités métiers (Club, Section, User, Categorie, Match, Tournoi, etc.) représentant la structure de la base de données.

- **ClubSportif.DAL**  
  Gère l'accès aux données avec Entity Framework Core. Il inclut le `DbContext` et la configuration Fluent API des entités.

- **ClubSportif.BLL**  
  Encapsule la logique métier et les règles de validation. Des services spécifiques (UserService, AuthService, etc.) y sont implémentés.

- **ClubSportif.DTO**  
  Définit les Data Transfer Objects (DTO) utilisés pour les échanges de données entre l'API et le frontend.

- **ClubSportif.Api**  
  Le projet Web API ASP.NET Core qui expose les endpoints REST et orchestre l'injection de dépendances entre les couches.

## Prérequis

Avant de démarrer, assurez-vous d'avoir installé :

- [.NET 9.0 SDK](https://aka.ms/dotnet/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ou une autre base de données compatible avec EF Core)
- Un IDE compatible (Visual Studio 2022+ ou Visual Studio Code)

## Structure de la Solution

La solution est organisée comme suit :

ClubSportif.sln
- ├── ClubSportif.Domain    // Entités métiers et modèles de données
- ├── ClubSportif.DAL       // Accès aux données, DbContext, configuration EF Core
- ├── ClubSportif.BLL       // Logique métier et services
- ├── ClubSportif.DTO       // Objets de transfert de données (DTO)
- └── ClubSportif.Api       // API REST ASP.NET Core

Chaque projet possède son fichier `.csproj` et est référencé par les autres pour faciliter l'injection de dépendances.

## Configuration

### Chaîne de Connexion

La chaîne de connexion à la base de données se trouve dans le fichier `appsettings.json` du projet **ClubSportif.Api** :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=VotreServeur;Database=ClubSportifDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "JwtSettings": {
    "Secret": "VotreCléGénéréeEnBase64",
    "Issuer": "ClubSportif",
    "Audience": "ClubSportifUsers",
    "ExpirationInMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Paramètres JWT

Les paramètres JWT (clé secrète, issuer, audience et expiration) sont utilisés par le service d’authentification pour générer des tokens. Ces paramètres sont injectés via l’objet JwtSettings dans le service AuthService.

## Installation et Exécution
- 1.	Cloner la solution :
```bash
git clone https://votre-repo-url.git
cd ClubSportif
```
- 2.	Restaurer les packages NuGet :
```bash
dotnet restore
```
- 3.	Construire la solution :
```bash
dotnet build
```
- 4.	Configurer la base de données :

Vérifiez que la chaîne de connexion dans appsettings.json est correcte. Ensuite, utilisez les migrations Entity Framework (si configuré) pour créer la base de données :
```bash
dotnet ef database update --project ClubSportif.DAL
```

- 5.	Lancer l’API :
```bash
dotnet run --project ClubSportif.Api
```


L’API sera accessible par défaut sur https://localhost:5001 (ou le port défini dans la configuration).

## Endpoints Principaux

Quelques exemples d’endpoints exposés :
-	•	AuthController
-	•	POST /api/Auth/login : Authentifie un utilisateur et renvoie un token JWT.
-	•	POST /api/Auth/register : Inscrit un nouvel utilisateur.
-	•	UsersController
-	•	GET /api/Users : Récupère la liste des utilisateurs.
-	•	GET /api/Users/{id} : Récupère un utilisateur par ID.
-	•	PUT /api/Users/{id} : Met à jour un utilisateur.
-	•	DELETE /api/Users/{id} : Supprime un utilisateur.
-	•	MatchsController, TournoisController, ConvocationsController, etc.
  
Ces contrôleurs gèrent respectivement la gestion des matchs, tournois et convocations.

Swagger est intégré pour documenter l’API. Accédez à la documentation via :
https://localhost:5001/swagger

## Migrations et Base de Données

La couche DAL utilise Entity Framework Core pour gérer la base de données. La configuration des entités et leurs relations se fait via Fluent API dans la méthode OnModelCreating du ClubSportifDbContext.

Pour appliquer une migration, utilisez :
```bash
dotnet ef migrations add InitialCreate --project ClubSportif.DAL
dotnet ef database update --project ClubSportif.DAL
```
Ces commandes créeront et appliqueront les migrations pour générer la base de données.

## Sécurité et Authentification

L’authentification se fait via JWT. Le service AuthService :
-	•	Vérifie les identifiants des utilisateurs.
-	•	Génère un token JWT contenant des claims (UserID, Email, Role).
-	•	Renvoie le token à l’utilisateur.

Les endpoints sensibles sont protégés via le middleware d’authentification et l’attribut [Authorize].

## Contributions

Les contributions sont les bienvenues ! Pour contribuer :
-	1.	Forkez le dépôt.
-	2.	Créez une branche pour votre fonctionnalité (feature/ma-nouvelle-fonctionnalité).
-	3.	Soumettez une Pull Request avec vos modifications.
-	4.	Assurez-vous que vos tests passent et que la documentation est à jour.

# Licence

Ce projet est sous licence MIT.

Ce format Markdown respecte la syntaxe pour les listes, les sections et le formatage global. Vous pouvez enregistrer ce contenu dans un fichier `README.md` à la racine de votre solution pour qu'il soit affiché correctement sur GitHub ou tout autre système de gestion de version.
