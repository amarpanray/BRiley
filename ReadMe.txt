Instructions.
	Solution comes with all necessary dependencies.
	Github Repository: https://github.com/amarpanray/BRiley
	Please run "create scripts" on your database. They are in a folder called "SQL Scripts" 

		Create Account.sql 
		Create Transaction.sql  		 

	    Update appsettings.json with YOUR connection string (or appsettings.Development.json if running IIS Express on a non-server machine).

About this application 
	Uses ASP.Net CORE 6.0
	Built using Visual Studio Community 2022
	Uses Dependency Injection
	Uses Repository Pattern
	Uses Database First (as requested by Vikas Chopra)
	Uses SQL Express (compatible with non express versions)


Step By Step Approach:
	Created a .Net Core solution using Visual Studio 2022 (Community Version).
	Designed 2 tables in the database. One for Accounts and one for Transactions.
	Installed Entity Framework with all necessary dependencies.
	Generated models from database using a Database First approach by running scaffolding script.

To Do:
	Extend FindByCondition method to use queries more efficiently.
	Use some async methods from repository for performance.
	Is AddScoped better than AddTransient when registering services in Start.cs
	Add Details page for All Transactions?
	Testing.