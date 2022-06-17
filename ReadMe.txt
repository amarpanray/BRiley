About this application 
	Uses ASP.Net CORE 6.0
	Built using Visual Studio Community 2022
	Uses Dependency Injection
	Uses Repository Pattern
	Uses SQL Express (compatible with non express versions)

Instructions.
	Solution comes with all necessary dependencies.
	Please run create scripts on your database. They are in a folder called "SQL Scripts" 

		Create table Account. Run First
		Create table Transaction. Run Second
		Create table Account_Transaction. Run Third

		Create Foreign Key Constraints to maintain data integrity
	    Update appsettings.json with YOUR connection string (or appsettings.Development.json if running IIS Express on a non-server machine).
