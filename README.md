# Drone Delivery Service

Test for Velozient, the requiriment is detailed next:

A squad of drones have been tasked with delivering packages for a major online reseller in a
world where time and distance do not matter. Each drone can carry a specific weight, and
can make multiple deliveries before returning to home base to pick up additional loads;
however the goal is to make the fewest number of trips as each time the drone returns to
home base it is extremely costly to refuel and reload the drone.
The purpose of the written software will be to accept input which will include the name of
each drone and the maximum weight it can carry, along with a series of locations and the
total weight needed to be delivered to that specific location. The software should highlight
the most efficient deliveries for each drone to make on each trip.

Assume that time and distance to each drop off location do not matter, and that size of each
package is also irrelevant. It is also assumed that the cost to refuel and restock each drone is
a constant and does not vary between drones. The maximum number of drones in a squad
is 100, and there is no maximum number of deliveries which are required.

Lastly, please supply an input data file. The client should be able to run the project and have
the results displayed.

Given Input
Line 1: [Drone #1 Name], [#1 Maximum Weight], [Drone #2 Name], [#2 Maximum Weight],
etc.
Line 2: [Location #1 Name], [Location #1 Package Weight]
Line 3: [Location #2 Name], [Location #2 Package Weight]
Line 4: [Location #3 Name], [Location #3 Package Weight]
Etc.
Expected Output
[Drone #1 Name]
Trip #1
[Location #2 Name], [Location #3 Name]
Trip #2

[Location #1 Name]

[Drone #2 Name]
Trip #1
[Location #4 Name], [Location #7 Name]
Trip #2
[Location #5 Name], [Location #6 Name]

## Starting 🚀

Main code is in a Github repository, you can clone or download it:

https://github.com/jaimepenaylillo/drone_delivery.git

Look at **Deployment** in order to deploy the project.

### Pre-requirements 📋

Need to Download or install SDK for .Net CLI, .NET 5.0 SDK or later:

https://dotnet.microsoft.com/download

### Instalation 🔧

Onece you clone or download the repository in your local machine then install .NET CLI SDK,
after that you can go to Cloned directory, then:

1. use cmd window in order to execute the solution,

2. Verify if SDK .Net CLI, is intalled:
   dotnet --version
3. you need to run

   dotnet restore

   In order to restore all projects dependencies,

## Libraries. ⚙️

All libraries are referenced in the drone_delivery-csproj file as follows:

<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <GenerateProgramFile>false</GenerateProgramFile>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Bogus" Version="33.0.2" />
    <PackageReference Include="Figgle" Version="0.4.0" />
    <PackageReference Include="json.net" Version="1.0.33" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.1" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.11.0-release-20210626-04" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3" />
  </ItemGroup>
</Project>

## Execution of program. ⚙️

For this example I hade create some Data Facke, using a NugetPackage called Bogus, this allow us to have randomic data, to test our application.

There are two ways to perform this task,

1.  To Run the project just

    dotnet run

2.  inside the directory,

        \bin\Release\netcoreapp3.1

    you have the file,

        drone_delivery.exe

clicking it you can execute the console application.

After that a console Aplication is been rised, asking for number of Drone in the fleet, you can input Eg. 100, after that the number of locations.
As is required the data is displayed: as follows:

EG. Using 2 as Drones in Fleet and 5 Locations.

$ dotnet run

---

| _ \ _ ** \_** \_ ** \_** | \_ \ **_| (_)\_ \_\_\_** _ \_\_ _ _| |
| | | | '\_\_/ _ \| '_ \ / _ \ | | | |/ _ \ | \ \ / / _ \ '**| | | | |
| |_| | | | (_) | | | | **/ | |_| | **/ | |\ V / **/ | | |_| |_|
|\_\_\_\_/|_| \_**/|_| |_|\_**| |\_**\_/ \_**|_|_| \_/ \_**|\_| \__, (_)
|\_**/

Enter Number Of Drone fleet: 2
Enter Number Of Location: 5
GIVEN INPUT
Drone #1, 915.653998458597000, Drone #2, 935.840793156922000
Location #1, 53.916671483738852
Location #2, 105.657846396629502
Location #3, 21.2514489191823946
Location #4, 489.902356383810878
Location #5, 381.800744996778973
EXPECTED OUTPUTOUTPUT
Drone #2
Trip#1
Location #3, Location #1, Location #2, Location #5
Drone #1
Trip#1
Location #4

After that you can press any key to continue and close the console.

## Developed using 🛠️

- [.Net CLI, .NET 5.0 SDK](https://dotnet.microsoft.com/download) - .net framework used
- [Visual Studio Code](https://code.visualstudio.com/) - Development Tool
- [Bogus](https://www.nuget.org/packages/Bogus/) - To have dummy data of drone and Locations.

## Authors ✒️

- **Jaime Pena y Lillo** - [Jaime Pena y Lillo](https://github.com/jaimepenaylillo)
