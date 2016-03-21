# Job Service Application Documentation #

## Project structure and architecture ##
The application code is divided into a couple different folders in order to keep the project organised as much as possible:

-  Folder "Core": contains the main logic of the application;
-  Folder "Clients": contains sample applications that illustrates the work the application. Two sample applications are provided - Console application and Windows Form application;
-  Folder "Test": contains unit tests that ensures the application logic's correctness;
-  Project "Logger": contains logic to log messages. It could be used as an external class library which is the reason why it is not in the "Core" folder.

## SOLID principles ##
- Single responsibility: the code is divided into well-structured classes that have only one purpose and one reason to be change e.g. TaskManager class is responsible to process Task classes;
- Open-closed: the code is open for extension but closed for modifications e.g. TaskManager class works with ITask class with allows to process any Task that implements ITask class. In addition the BaseSqlTask works with IDbConnection and IDbCommand which allows different sql servers to be plug in;
- Liskov substitution: all subclasses are substitutable for their base class e.g. BaseTask - SqlBackUpTask;
- Interface segregation: all interfaces are small, well-divided, containing only methods that are required e.g. ITaskManager have only one method - ProcessTask;
- Dependency inversion: entities depend on abstractions not on concretions e.g. TaskManager depends on ILogger which could be changed with different Logger classes that implement ILogger interface and it's methods.

## Used design patterns ##
- Factory: SqlTaskFactory provides SqlTasks (SqlBackupTask and SqlRestoreTask). The class encapsulates object creation logic making specific class selection logic changes in one place. This gives an opportunity to the clients of the application to get an instance of SqlTask by calling one method only;
- Stategy: Encapsulates an algorithm inside a class making each algorithm replaceable by others e.g. ITask - SqlBackUpTask, ITaskManager - TaskManager, ISqlTaskFactory - SqlTaskFactory. This also makes test easier to be written because strategies can be mocked;
- Template: method Execute() in BaseSqlTask class. The mehotd defines the base of the execute task algorithm, leaving some implementation to its subclasses (ExecuteSqlCommand()). In this way subclasses redifine the implementation of some of the parts of the algorithms but can not change the algorithm structure;
- Observer (Publish-Subscribe): when one object changes state, all its observers are notified e.g. when task finish executing it notifies its subscribers (clients) and they notified the client of the application (in the console client the application writes on the console; in windows form application a pop up box is displayed to notify the client).


## Inversion of control ##
Ninject is put in use to provide required dependencies:

- TaskManager depends on ILogger;
- A single instance of TaskManager is given back when a TaskManager instance is requested(Singleton design pattern).

## External libraries ##
- Ninject for IoC;
- NUnit for testing; 
- Moq to Mock objects.
