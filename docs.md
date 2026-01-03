# 🍽️ Système de Gestion de Restaurant (RMS)

## 📌 Présentation générale

Le **Restaurant Management System (RMS)** est une application desktop développée en **.NET Framework (Windows Forms)** avec **Microsoft SQL Server**, utilisant **Entity Framework 6 (Database First)** comme ORM.

L’objectif principal du projet est de modéliser des **processus réels de gestion de restaurant**, d’appliquer une **logique métier claire**, et de fournir une **architecture propre et collaborative** adaptée à un projet académique.

---

## 🧱 Stack Technique

* **Langage :** C#
* **Framework :** .NET Framework 4.7.2
* **Interface utilisateur :** Windows Forms
* **ORM :** Entity Framework 6.4.4 (Database First)
* **Base de données :** Microsoft SQL Server (SQL Express)
* **Accès aux données :** System.Data.SqlClient
* **Architecture :** Architecture en couches (Layered Architecture)

---

## 🗂️ Architecture du Projet

La solution est organisée en **trois projets principaux**, chacun ayant une responsabilité bien définie.

```
Restaurant-Management-System.sln
│
├── RestaurantManagSyst.Data          (Accès aux données & modèles EF)
├── RestaurantManagSyst.Service       (Logique métier)
├── RestaurantManagSyst.Presentation  (Interface utilisateur WinForms)
└── packages / NuGet.config / .sln
```

---

## 📁 Structure réelle de la solution

### 1️⃣ RestaurantManagSyst.Data (Couche Données)

**Responsabilités :**

* Accès à la base de données
* Mapping Entity Framework
* Représentation des entités

**Contenu principal :**

```
RestaurantManagSyst.Data
│
├── RestaurantModel.edmx            (Modèle EF)
├── RestaurantModel.Context.cs      (DbContext)
├── RestaurantModel.Designer.cs     (Code généré EF)
├── Entités (.cs)
│   ├── Users.cs
│   ├── Clients.cs
│   ├── Employees.cs
│   ├── MenuItems.cs
│   ├── Ingredients.cs
│   ├── IngredientInventory.cs
│   ├── ProductInventory.cs
│   ├── Orders.cs
│   ├── OrderItems.cs
│   ├── Payments.cs
│   └── PaymentMethods.cs
│
├── App.config                      (Chaîne de connexion)
└── packages.config                 (Dépendances EF)
```

🔹 **Règle importante :**

* Aucune logique métier dans cette couche
* Uniquement la persistance et les entités

---

### 2️⃣ RestaurantManagSyst.Service (Couche Logique Métier)

**Responsabilités :**

* Application des règles métier
* Validation des opérations
* Coordination entre l’UI et la base de données

**Contenu principal :**

```
RestaurantManagSyst.Service
│
├── DTOs            (Objets de transfert de données)
├── Enums           (Statuts, rôles, etc.)
├── Helpers         (Hashage, utilitaires)
├── IServices       (Interfaces)
├── Services        (Implémentations)
│   ├── AuthService.cs
│   ├── OrderService.cs
│   ├── InventoryService.cs
│   ├── PaymentService.cs
│   └── MenuService.cs
│
├── App.config
└── packages.config
```

🔹 **Importance de cette couche :**

* Centralise toutes les règles du restaurant
* Empêche l’UI d’accéder directement à la base de données

---

### 3️⃣ RestaurantManagSyst.Presentation (Couche Présentation)

**Responsabilités :**

* Interaction avec l’utilisateur
* Affichage des données
* Appel exclusif de la couche Service

**Contenu principal :**

```
RestaurantManagSyst.Presentation
│
├── Formulaires WinForms
│   ├── Form_Login.cs
│   ├── Form_Dashboard.cs
│   ├── Form_ClientList.cs
│   ├── Form_EmployeeList.cs
│   ├── Form_MenuItemList.cs
│   ├── Form_IngredientList.cs
│   ├── Form_InventoryList.cs
│   ├── Form_OrderList.cs
│   └── Form_PaymentMethodList.cs
│
├── Resources
├── Program.cs
├── App.config
└── packages.config
```

🔹 **Règles UI :**

* Aucune requête SQL directe
* Aucune logique métier
* Utilisation exclusive des services

---

## 🔐 Authentification & Gestion des rôles

### Rôles

* Administrateur
* Caissier

### Fonctionnalités

* Connexion sécurisée (mots de passe hashés)
* Accès basé sur les rôles
* Activation / désactivation des utilisateurs

---

## 🧾 Gestion des Clients (CRUD)

* Ajouter un client
* Afficher la liste des clients
* Modifier les informations
* Supprimer un client
* Rechercher un client

---

## 👨‍🍳 Gestion des Employés (CRUD)

* Ajouter un employé
* Modifier / supprimer un employé
* Assigner des employés aux commandes

---

## 🍔 Gestion des Articles du Menu

### Fonctionnalités

* Image du produit
* Prix d’achat & prix de vente
* Catégorie & temps de préparation
* Activation / désactivation

---

## 🧂 Gestion des Ingrédients

* Ajouter / modifier / supprimer
* Définir quantité et unité (g, kg, L, ml)

---

## 🔗 Liaison Menu ↔ Ingrédients

* Associer des ingrédients aux plats
* Vérification du stock avant commande

---

## 📦 Gestion du Stock

### Stock des ingrédients

* Suivi automatique après chaque vente

### Stock des produits (ProductInventory)

```sql
CREATE TABLE ProductInventory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    ReorderLevel INT NOT NULL DEFAULT 0,
    LastUpdated DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_ProductInventory_MenuItems
        FOREIGN KEY (MenuItemId) REFERENCES MenuItems(Id)
);
```

---

## 🛒 Gestion des Commandes

### Statuts

* En attente
* En préparation
* Terminée
* Annulée

### Fonctionnalités

* Création de commande
* Ajout / suppression d’articles
* Calcul automatique du total
* Historique des commandes

---

## 💳 Méthodes de Paiement

* Ajouter / modifier
* Activer / désactiver
* Supprimer

---

## 💰 Paiements

* Paiement d’une commande
* Choix de la méthode de paiement
* Ajout de pourboires

---

## 👥 Collaboration & Objectif Académique

* Travail en branches Git
* Architecture propre et maintenable
* Application de bonnes pratiques professionnelles

---

## 🚀 Améliorations futures

* Rapports & statistiques
* Gestion avancée des permissions
* Version mobile ou API REST

---

**Document préparé pour la collaboration d’équipe et la présentation académique.**
