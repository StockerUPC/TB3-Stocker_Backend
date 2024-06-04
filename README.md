# Stocker

## Summary
Stocker Application, made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence. It also illustrates open-api documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- ASP.NET Framework
- Entity Framework Core
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions.
- MySQL Database
- Domain-Driven Design

## Bounded Contexts
This version of Stocker is divided into two bounded contexts: Profiles, and Products (for the moment).

### Profiles Context

The Profiles Context is responsible for managing the profiles of the users. It includes the following features:

- Create a new profile.
- Get a profile by id.
- Get all profiles.

This context includes also an anti-corruption layer to communicate with the Product Context. The anti-corruption layer is responsible for managing the communication between the Profiles Context and the Product Context. It offers the following capabilities to other bounded contexts:
- Create a new Profile, returning ID of the created Profile on success.
- Get a Profile by Email, returning the associated Profile ID on success.

### Products Context

The Products Context is responsible for managing the creation of Products. Its features include:

- Create a Category.
- Get a Category by id.
- Get All Categories.
- Create a Product.
- Get a Product by Id
- Get Products by Category Id.
- Get All Products.

#### Preguntas https://docs.google.com/document/d/1VlZqdeUQLyMANlUfrii1uSao-vePj4SiMWKkyaowcJg/edit?usp=sharing

https://miro.com/welcomeonboard/V25lV09hZlVadExPMEZrNXBydHliSXBZd3JiQkxNQnZPY3Y1QTQ2MWw2cFhNZ1locXhKbFJJMFBYNlVYRkZIMXwzNDU4NzY0NTkwODI0MzAwODc0fDI=?share_link_id=803417857238 