Steps:

1. Install THREE NuGet Packages
   1. EntityFrameworkCore
   2. EntityFrameworkCore.SqlServer
   3. EntityFrameworkCore.Tools

   Note: Need to pick the same version for all the packages.
    
2. Create a Model
3. Create a DbContext class
4. Create a Connection String in appsettings.json
5. Add DbcContext in Program.cs to the services section
6. Update the database using the following command
   ```
   Add-Migration InitialCreate // This will create a migration folder with the initial schema
   // i can make updates to the db and then make a new migration and it will know the changes I made w/o specifying
   Update-Database
   // this will start running all the migrations and update the database iteself
   ```
    



Notes on Structure
Pages --> Items: This will contain the scaffolded pages for the CRUD operations for just the Items table (we would make a folder for each table we want to scaffold))