# Gestion de Brasserie et Grossiste

Ce projet implémente un système de gestion de brasserie et de grossistes. L'API REST fournit des fonctionnalités telles que la liste des bières par brasserie, la création d'une nouvelle bière, l'ajout de ventes de bières à un grossiste, la mise à jour des quantités de bières chez un grossiste, et d'autres fonctionnalités spécifiées dans les contraintes.

## Fonctionnalités

- Lister l’ensemble des bières par brasserie et les grossistes qui la vendent
- Création d’une nouvelle bière
- Ajout de la vente d’une bière existante à un grossiste existant
- Mise à jour de la quantité restante d’une bière chez un grossiste
- Supprimer une bière d’un brasseur
- Demander un devis à un grossiste

## Contraintes Métiers

- Un brasseur brasse plusieurs bières différentes, une bière est forcément liée à un brasseur
- Un grossiste vend plusieurs bières différentes, de n’importe quel brasseur, et n’en a qu'un stock limité, à un prix fixe (celui défini par le brasseur)
- Une bière peut être vendue dans plusieurs grossistes
- On considère que toutes les ventes se font HTVA

## Exemple de Données

### Brasserie

- Nom: Abbaye de Leffe

### Bière

- Nom: Leffe Blonde
- Degré d’alcool: 6,6 %
- Prix: 2,20

### Grossiste

- Nom: GeneDrinks

    - Un grossiste vend une liste définie de bière, au prix imposé par la brasserie et ne possède qu’une certaine quantité.
    - GeneDrinks a 10 Leffe Blonde en stock.

## Contraintes Techniques

- Respect de l’architecture REST
- Entity Framework (6 ou Core)
- Tester unitairement le code le nécessitant.
- Pas de frontend, l’API doit répondre via des requêtes HTTP
- Dépôt Git (Github / Azure DevOps, Gitlab, …)
