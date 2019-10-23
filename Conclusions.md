# Project conclusions
## What to do
+ Use xUnit
+ Fix namespaces
+ Use microservices
+ Use model validation
+ TDD
## What to consider
+ Swagger with angular generator
+ Automapper
+ Extract AbstractEndpointTests to library
+ Logic layer does not make sense in this kind of project as it's mostly CRUD
+ Moq
+ Split project into smaller ones. Eg DatabaseAPI may be splitted into: Database.API
and Database.DataAccess
## What not to do
+ Using commands in the logic layer does not seem reasonable, at least specified 
commands for every layer