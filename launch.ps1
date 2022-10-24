#git clone https://github.com/nunosantos/promotion-engine.git
#cd promotion-engine
#git checkout -b "add-initial-framework"

mkdir ApiGateway
mkdir Utilities
mkdir Services

dotnet new sln -n BurgerBackend

cd ApiGateway
mkdir BurgerBackend.GW
dotnet new webapi --output BurgerBackend.GW --language "c#"
dotnet add package Serilog
dotnet add package Ocelot
dotnet add package Ocelot.Cache.CacheManager
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations

mkdir BurgerBackend.Aggregator
dotnet new webapi --output BurgerBackend.Aggregator --language "c#"
dotnet add package Microsoft.VisualStudio.Azure.Containers.Tools.Targets
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations

cd ..

cd Utilities
dotnet new classlib --output BurgerBackend.Common --language "c#"

cd .. 

cd Services

mkdir Restaurant

cd Restaurant

mkdir src
mkdir tests

cd src

dotnet new classlib --output Restaurant.Domain --language "c#"
dotnet new classlib --output Restaurant.Application --language "c#"
dotnet new classlib --output Restaurant.Infrastructure --language "c#"
dotnet new webapi --output Restaurant.API --language "c#"

dotnet add package Microsoft.VisualStudio.Azure.Containers.Tools.Targets
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations
cd..

cd tests

dotnet new xunit --output Unit-tests --language "c#"
dotnet new xunit --output Integration-tests --language "c#"
dotnet add package FluentAssertions
dotnet add package Newtonsoft.Json

cd ..

cd ..

mkdir Location

cd Location

mkdir src
mkdir tests

cd src

dotnet new classlib --output Location.Domain --language "c#"
dotnet new classlib --output Location.Application --language "c#"
dotnet new classlib --output Location.Infrastructure --language "c#"
dotnet new webapi --output Location.API --language "c#"

dotnet add package Microsoft.VisualStudio.Azure.Containers.Tools.Targets
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations

cd ..

cd tests

dotnet new xunit --output Unit-tests --language "c#"
dotnet new xunit --output Integration-tests --language "c#"
dotnet add package FluentAssertions
dotnet add package Newtonsoft.Json

cd ..

cd ..

mkdir ResourceManagement

cd ResourceManagement

mkdir src
mkdir tests

cd src

dotnet new classlib --output ResourceManagement.Domain --language "c#"
dotnet new classlib --output ResourceManagement.Application --language "c#"
dotnet new classlib --output ResourceManagement.Infrastructure --language "c#"
dotnet new webapi --output ResourceManagement.API --language "c#"

dotnet add package Microsoft.VisualStudio.Azure.Containers.Tools.Targets
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations
cd ..

cd tests

dotnet new xunit --output Unit-tests --language "c#"
dotnet new xunit --output Integration-tests --language "c#"
dotnet add package FluentAssertions
dotnet add package Newtonsoft.Json

cd ..

cd ..

cd ..

dotnet sln add Services/ResourceManagement/src/ResourceManagement.Domain
dotnet sln add Services/ResourceManagement/src/ResourceManagement.Application
dotnet sln add Services/ResourceManagement/src/ResourceManagement.API
dotnet sln add Services/ResourceManagement/src/ResourceManagement.Infrastructure
dotnet sln add Services/ResourceManagement/tests/Unit-tests
dotnet sln add Services/ResourceManagement/tests/Integration-tests
			   
dotnet sln add Services/Location/src/Location.Domain
dotnet sln add Services/Location/src/Location.Application
dotnet sln add Services/Location/src/Location.API
dotnet sln add Services/Location/src/Location.Infrastructure
dotnet sln add Services/Location/tests/Unit-tests
dotnet sln add Services/Location/tests/Integration-tests
			   
dotnet sln add Services/Restaurant/src/Restaurant.Domain
dotnet sln add Services/Restaurant/src/Restaurant.Application
dotnet sln add Services/Restaurant/src/Restaurant.API
dotnet sln add Services/Restaurant/src/Restaurant.Infrastructure
dotnet sln add Services/Restaurant/tests/Unit-tests
dotnet sln add Services/Restaurant/tests/Integration-tests

dotnet sln add ApiGateway/BurgerBackend.GW

dotnet sln add ApiGateway/BurgerBackend.Aggregator

dotnet sln add Utilities/BurgerBackend.Common

dotnet build
dotnet test
#git branch
