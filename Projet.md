
# TP C# avancé

A partir du code réalisé en cours, vous allez implémenter une authentification forte avec ASP Identity Core dans votre application.

# I- Sujet

## Application 

Vous devez reprendre l'application faite en cours (vous pouvez récupérer le GIT du prof).

## ASP Identity (5 points)

Vous allez devoir implémenter la librairie [ASP Identity Core](https://docs.microsoft.com/fr-fr/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio)
Les données seront enregistrées en base de données, il faudra donc connecter ASP Identity avec [Entity Framework](https://docs.microsoft.com/fr-fr/aspnet/core/migration/identity?view=aspnetcore-3.1)
Vous allez gérer les utilisateurs et les roles, PAS les claims.

## Connexion, déconnexion (5 points)

Vous allez créer une page de Login.
Un lien "connexion" ou le nom de l'utilisateur connecté (avec un bouton déconnexion) devra apparaitre dans la barre de menu de l'application.
Pour afficher le nom de l'utilisateur connecté, vous devez créer et utiliser un [TagHelper](https://docs.microsoft.com/fr-fr/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-3.1)

## Filtres (3 points)

Pour les modèles et les marques, les parties Ajout, modification et supression seront soumises à une identification pour être [accessibles](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute?view=aspnetcore-3.1)

## Administration des utilisateurs (7 points)

Vous allez créer une [Area](https://docs.microsoft.com/fr-fr/aspnet/core/mvc/controllers/areas?view=aspnetcore-3.1) pour administrer les utilisateurs.
Cette area ne sera uniquement accessible aux utilisateurs connectés qui auront le role ADMIN.
Il y aura donc 2 roles, ADMIN et SIMPLE
Dans cette area, on doit pouvoir:
 - ajouter / modifier / supprimer un utilisateur
 - ajouter ou supprimer des roles aux utilisateurs

## Bonus (3 points)
Dans l'area d'administration, on rajoute:
 - La liste des utilisateurs actullement connectés.
 - Pouvoir déconnecter un utilisateur connecté.

# Fonctionnement

Le projet est a développé en INDIVIDUEL et sera noté en INDIVIDUEL.
Le projet sera réalisé le Jeudi 22 octobre 2020 de 9h15 à 18h15.

# Rendu

Toute absence de rendu à 18h15 entrainera un 0 (ZERO) pour l'étudiant.

Le rendu s'effectu via un repos GIT ou SVN. L'adresse du rendu est envoyé par mail.
Le mail de rendu est vincent.leclerc@ynov.com
Les fichiers rendus doivent contenir
  - L'arborescence du projet, immédiatement exploitable après création des bases de données et exécution des migrations.
  - Un AUTHORS.TXT listant le prénom et nom de l'étudiant.
Le sujet du mail doit contenir votre section ainsi que votre nom.
Un code qui ne compile pas ou ne s'éxécute pas ne sera pas noté (conseil: faites des branches git)
