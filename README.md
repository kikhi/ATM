# ATM

_Simple ATM, cross plataform_

## Get Started 🚀

_CRUD instructions for traning or upgrade to a serious project_

_The project is already build for the product use but remember the defaul values of the database is SERVER=CLIENTE\SQLEXPRESS; DATABASE=criptos; integrated security=true_

### Pre-requisites and builded with 📋 🛠️

* [.net 6](https://dotnet.microsoft.com/en-us/download) - dotnet 6.0.1
* [SQL server](https://www.microsoft.com/es-mx/sql-server/sql-server-downloads) - For database development
* [git](https://git-scm.com/) - For branching
* [vs code](https://code.visualstudio.com/) - For code edit

_Sql server conection_

```
dotnet add package System.Data.SqlClient --version 4.8.3
```

_Unit Testings_
```
dotnet add package Microsoft.VisualStudio.UnitTesting --version 11.0.50727.1
```

### Instalation 🔧

_You can download the project and use the program with .exe or modify the source code for upgrade it_

_Once downloaded on bin file you can find the .exe program_

```
C: \ATM> cd bin 
```

_You can also upgrade the project cloning the repository or download in a zip_
```
git clone https://github.com/kikhi/ATM.git
```

### Run and Unit Testing ⌨️

_For run project use the fallow command_
```
dotnet run
```

_xUnit used for this project_
```
dotnet new xunit -o AlgebraTests
```

_Add reference from project to testing project_
```
dotnet add AlgebraTests/AlgebraTests.csproj reference Algebra.csproj
```

_For test code use fallow command_
```
dotnet test AlgebraTests/AlgebraTests.csproj
```

_If the second time testing there are problems, put the follow instruction on files .csproj from project and test project_
```
<GenerateAssemblyInfo> false </GenerateAssemblyInfo>
```

## Deploy 📦

_For deployment need build the project_

```
dotnet build
```

_Then you can publish the project or take the .exe for personal use_

## Licence 📄

This project is for free use - See the licence [LICENSE.md](LICENSE.md) for more details


---
Made by [kikhi](https://github.com/kikhi) 😊