# Game Tracker

#### _A place to track your games and consoles, 5/21/2021_

#### By _**James Wyn, Thomas Friedrichs & Tiffany Greathead**_

## Description

A user can create an account and add to a list of consoles and games. A user can also assign a game to multiple consoles, or vice versa.

## Setup and Use

### Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- A text editor like [VS Code](https://code.visualstudio.com/)
- A command line interface like Terminal or GitBash to run and interact with the console app
- [MySQL Community Server](https://dev.mysql.com/downloads/file/?id=484914)

### Installation

1. Clone the repository: `$ git clone https://github.com/TorchAblaze/GameTracker.Solution.git`
2. Navigate to the `GameTracker.Solution` directory on your computer
3. Open with your preferred text editor to view the code base
4. To setup a SQL database using MySQL:
   - Create an `appsettings.json` file in the `GameTracker` directory
   - Copy the text box below and paste into the `appsettings.json` file, replacing `<password>` with your MySQL password:
   ```
     {
        "ConnectionStrings": {
           "DefaultConnection": "Server=localhost;Port=3306;database=tiffany_greathead;uid=root;pwd=<password>;"
         }
     }
   ```
   - Open your terminal and run the command: `mysql -uroot -p<mysql_password>` (replace `<mysql_password>` with your MySQL password) and select the enter key to launch MySQL servers
5. To run the console app:
   - Navigate to `GameTracker.Solution/GameTracker` in your command line
   - Run the commands:
     - `dotnet restore` to restore the dependencies that are listed in `GameTracker.csproj`
     - `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
     - `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
     - `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
     - `dotnet build` to build the project and its dependencies into a set of binaries
     - `dotnet tool install --global dotnet-ef` to install EF Core tools
     - `dotnet ef migrations add Initial` and `dotnet ef database update`
   - Finally, run the command `dotnet run` to run the project!
   - Note: `dotnet run` also restores and builds the project, so you can use this single command to start the console app
6. Visit the application via web browser at: `localhost:5000/`

## Known Bugs

_No known bugs_ :bug:

## Support and contact details

_Please reach out through our GitHub accounts._

## Technologies Used

- C#
- .NET 5 SDK
- ASP.NET
- Entity Framework Core
- MySQL
- Bootstrap

### License

<details>
<summary><a href="https://opensource.org/licenses/MIT"><strong>MIT</strong></a></summary>
<pre>
MIT License

Copyright (c) 2021 James Wyn, Thomas Friedrichs & Tiffany Greathead

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

</pre>
</details>

Copyright ?? 2021 **_James Wyn, Thomas Friedrichs & Tiffany Greathead_**
