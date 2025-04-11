# ParkingManagement

## Aperçu du Projet

ParkingManagement est une application complète de gestion de parkings qui permet d'administrer des emplacements de stationnement, de suivre leur occupation, et de gérer les interactions avec les clients et les artisans. Le système est conçu avec une architecture moderne en utilisant .NET, Entity Framework Core et Blazor.

## Architecture

Le projet est divisé en deux parties principales:

### Backend (API)

Le backend suit une architecture en couches avec:

- **ParkingManagement.Api**: Contrôleurs REST et point d'entrée de l'application
- **ParkingManagement.Core**: Entités du domaine, interfaces et DTOs
- **ParkingManagement.Services**: Implémentation des services métier
- **ParkingManagement.Infrastructure**: Persistance des données et implémentations d'infrastructure

### Frontend

- **ParkingManagement**: Application Blazor pour l'interface utilisateur

## Technologies Utilisées

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- JWT pour l'authentification
- AutoMapper pour le mapping objet-objet
- Swagger pour la documentation API

### Frontend
- Blazor WebAssembly
- Services HTTP pour la communication avec l'API
- CSS pour la mise en page et le design

## Fonctionnalités Principales

- Gestion complète des parkings (ajout, suppression, modification)
- Gestion des utilisateurs et des rôles (Admin, Client, Artisan)
- Authentification et autorisation basées sur JWT
- Planification des jours d'ouverture des parkings
- Gestion des services d'artisans dans les parkings
- Téléchargement et gestion d'images pour les parkings

## Modèles de Données

- **Parking**: Gestion des emplacements de stationnement avec leurs informations
- **User**: Utilisateurs du système (Admin, Client, Artisan)
- **Artisan**: Prestataires de services dans les parkings
- **Client**: Utilisateurs des services de parking
- **ParkingDay**: Jours d'ouverture des parkings
- **ArtisanClientService**: Services fournis par les artisans aux clients

## Configuration et Installation

### Prérequis
- .NET 6.0 ou supérieur
- SQL Server
- Visual Studio 2022 ou VS Code

### Étapes d'installation

1. Cloner le dépôt
```bash
git clone https://github.com/kadimohammed/ParkingManagement.git
```

2. Configurer la chaîne de connexion dans le fichier `appsettings.json` du projet API

3. Appliquer les migrations Entity Framework pour créer la base de données
```bash
cd BackEnd/ParkingManagement.Api
dotnet ef database update
```

4. Exécuter le backend
```bash
dotnet run
```

5. Dans un autre terminal, exécuter le frontend
```bash
cd FrontEnd/ParkingManagement
dotnet run
```

## Sécurité

L'application utilise JWT pour l'authentification et implémente des contrôles d'autorisation basés sur les rôles. Les mots de passe sont hachés avant d'être stockés dans la base de données.

## Structure des API

- **GET /api/Parking**: Récupérer tous les parkings
- **GET /api/Parking/{id}**: Récupérer un parking spécifique
- **POST /api/Parking**: Ajouter un nouveau parking (Admin uniquement)
- **PUT /api/Parking**: Mettre à jour un parking existant (Admin uniquement)
- **DELETE /api/Parking/{id}**: Supprimer un parking (Admin uniquement)
- **POST /api/Authentication/login**: Authentifier un utilisateur
- **POST /api/Authentication/register**: Inscrire un nouvel utilisateur

## Contributeurs

- Mohammed KADI
