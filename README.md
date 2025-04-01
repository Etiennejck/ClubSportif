
ClubSportif Backend API

Ce projet constitue le backend d’une application de gestion de club sportif. Il est développé en ASP.NET Core et s’appuie sur une architecture multicouche pour assurer une séparation claire des responsabilités, faciliter la maintenance et permettre une évolution agile de l’application.

Table des Matières
	•	Aperçu du Projet
	•	Architecture
	•	Prérequis
	•	Structure de la Solution
	•	Configuration
	•	Installation et Exécution
	•	Endpoints Principaux
	•	Migrations et Base de Données
	•	Sécurité et Authentification
	•	Contributions
	•	Licence

⸻

Aperçu du Projet

Le backend de ClubSportif fournit les API REST nécessaires à la gestion du club sportif. Les fonctionnalités principales incluent :
	•	Gestion des utilisateurs (joueurs, coachs, administrateurs)
	•	Gestion des clubs, sections et catégories
	•	Suivi des disponibilités et des présences
	•	Gestion des matchs, tournois et convocations
	•	Authentification (login, inscription) avec génération de tokens JWT

⸻

Architecture

Le projet suit une architecture multicouche composée des cinq projets suivants :
	•	ClubSportif.Domain
Contient les entités métiers (Club, Section, User, Categorie, Match, Tournoi, etc.) qui reflètent la structure de la base de données.
	•	ClubSportif.DAL
Gère l’accès aux données via Entity Framework Core. Il inclut la configuration du DbContext et les repositories.
	•	ClubSportif.BLL
Encapsule la logique métier et les règles de validation. Des services spécifiques (UserService, AuthService, etc.) y sont implémentés.
	•	ClubSportif.DTO
Définit les Data Transfer Objects utilisés pour les échanges de données entre l’API et le frontend.
	•	ClubSportif.Api
Le projet Web API ASP.NET Core qui expose les endpoints REST et orchestre l’injection de dépendances entre les couches.

⸻

Prérequis

Avant de démarrer, assurez-vous d’avoir installé :
	•	.NET 9.0 SDK
	•	SQL Server (ou une autre base compatible avec EF Core)
	•	Un IDE compatible (Visual Studio 2022+ ou Visual Studio Code)

⸻

Structure de la Solution

La solution se compose de plusieurs projets pour respecter la séparation des responsabilités :

ClubSportif.sln
├── ClubSportif.Domain    // Entités métiers et modèles de données
├── ClubSportif.DAL       // Accès aux données, DbContext, configuration EF Core
├── ClubSportif.BLL       // Logique métier et services
├── ClubSportif.DTO       // Objets de transfert de données (DTO)
└── ClubSportif.Api       // API REST ASP.NET Core

Chaque projet possède son fichier .csproj et est référencé en conséquence pour faciliter l’injection de dépendances.

⸻

Configuration

Chaîne de Connexion

La chaîne de connexion à la base de données se trouve dans le fichier appsettings.json du projet ClubSportif.Api :

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

Paramètres JWT

Les paramètres JWT (clé secrète, issuer, audience et expiration) sont utilisés par le service d’authentification pour générer des tokens. Ils sont injectés via l’objet JwtSettings dans le service AuthService.

⸻

Installation et Exécution
	1.	Cloner la solution :

git clone https://votre-repo-url.git
cd ClubSportif


	2.	Restaurer les packages NuGet :

dotnet restore


	3.	Construire la solution :

dotnet build


	4.	Configurer la base de données :
Assurez-vous que la chaîne de connexion dans appsettings.json est correcte. Vous pouvez ensuite utiliser les migrations Entity Framework (si configuré) pour créer la base :

dotnet ef database update --project ClubSportif.DAL


	5.	Lancer l’API :

dotnet run --project ClubSportif.Api

L’API sera accessible par défaut sur https://localhost:5001 ou un autre port défini dans la configuration.

⸻

Endpoints Principaux

Voici quelques exemples d’endpoints exposés par l’API :
	•	AuthController
	•	POST /api/Auth/login : Authentifier un utilisateur et obtenir un token JWT.
	•	POST /api/Auth/register : Inscrire un nouvel utilisateur.
	•	UsersController
	•	GET /api/Users : Récupérer la liste des utilisateurs.
	•	GET /api/Users/{id} : Récupérer un utilisateur par ID.
	•	PUT /api/Users/{id} : Mettre à jour un utilisateur.
	•	DELETE /api/Users/{id} : Supprimer un utilisateur.
	•	MatchsController, TournoisController, ConvocationsController, etc.
Ces contrôleurs gèrent respectivement les opérations liées aux matchs, tournois et convocations.

Swagger est intégré pour documenter l’API. Vous pouvez accéder à la documentation Swagger en naviguant sur https://localhost:5001/swagger.

⸻

Migrations et Base de Données

La couche DAL utilise Entity Framework Core pour gérer la base de données. Les entités et leurs relations sont configurées via Fluent API dans la méthode OnModelCreating du ClubSportifDbContext.

Pour appliquer une migration, utilisez les commandes EF Core (assurez-vous d’avoir installé le package Microsoft.EntityFrameworkCore.Tools) :

dotnet ef migrations add InitialCreate --project ClubSportif.DAL
dotnet ef database update --project ClubSportif.DAL

Ces commandes créeront et appliqueront les migrations pour générer la base de données.

⸻

Sécurité et Authentification

L’authentification se fait via JWT. Le service AuthService vérifie les identifiants des utilisateurs, génère un token JWT contenant les claims (UserID, Email, Role) et le renvoie à l’utilisateur.

Les endpoints sensibles sont protégés grâce au middleware d’authentification et aux attributs [Authorize] sur les contrôleurs et actions nécessitant une autorisation.

⸻

Contributions

Les contributions sont les bienvenues ! Pour contribuer :
	1.	Forkez le dépôt.
	2.	Créez une branche pour votre fonctionnalité (feature/ma-nouvelle-fonctionnalité).
	3.	Soumettez une Pull Request avec vos modifications.
	4.	Assurez-vous que vos tests passent et que la documentation est à jour.

⸻

Licence

Ce projet est sous licence MIT.

⸻
