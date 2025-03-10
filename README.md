## Day 1
### Assignment 1: Implement different EF Core setup methods in a single .NET Core Web API project. Each method should be in a separate branch of your repository for easy comparison.
1. Standard EF Core Setup (Basic DI Registration)
2. Using OnConfiguring() for DbContext Setup (No DI)
3. Environment-Based Connection String Selection
![day1_1](/img/day1_1.png)

### Assignment 2: Implement different ways to configure DbContext using Dependency Injection (DI) in a .NET Core Web API project and analyze the impact of using Singleton, Scoped, and Transient lifetimes.
![day1_2_Scoped](/img/day1_2_Scoped.png)
![day1_2_Singleton](/img/day1_2_Singleton.png)
![day1_2_Transient](/img/day1_2_Transient.png)

## Day 2
Project Setup
1. Create a .NET Core Web API project.
2. Configure Entity Framework Core and define a DbContext with at least three related entities (Schema choice will be yours) :
○ Customer (One-to-Many → A customer can have multiple orders).
○ Order (Many-to-Many ↔ An order can contain multiple products, and a product can be in multiple orders).
○ Product

Define entity classes (models) and map them to database tables using both:
● Data Annotations (attributes for defining primary keys, relationships, constraints, etc.).
● Fluent API (override the OnModelCreating method in DbContext to configure relationships and constraints).
Implement primary keys and composite keys where necessary.
SQL Query Logging
● Enable logging to capture and display the actual SQL queries executed by LINQ queries in the console or logs.
![day2_1](/img/day2_1.png)

