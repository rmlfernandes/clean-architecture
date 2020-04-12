# Clean Architecture
This solution follows the Clean Architecture and it is a demo app for learning purposes.

![alt text](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg "The Clean Architecture")


### Overview

##### Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

##### Application
This layer contains all application logic. It is dependent on the domain layer but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application needs to access a notification service, a new interface would be added to the application and the implementation would then be created in the infrastructure layer.

##### Infrastructure
This layer contains classes to handler persistence and accessing external resources. These classes should be based on interfaces defined within the application layer.

##### WebAPI
This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.