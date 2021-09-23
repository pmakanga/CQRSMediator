# What is CQRS Pattern
CQRS stands for Command Query Responsibility Segregation, this pattern states to separate read and write operations for a data source. Each method should either be a Command or a Query but not both. In CQRS “Commands” is known for database saves and “Queries” is known for reading from the database.

The idea behind CQRS is to have different models for different operations. So for a CRUD operation we will have 4 models which are:

1. A model for creating records.
2. A model for reading records.
3. A model for updating records.
4. A model for deleting records.

# What is Mediator Pattern
The Mediator pattern defines an object called Mediator, this Mediator encapsulates how a set of objects interact with one another. 
Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
The Mediator pattern ensures that components don’t call each other explicitly, but instead do so through calls to a mediator.
