Develop Environment:

- Windows 8.1 64 bits.
- Visual Studio Community 2013 Version 12.0.
- Install SQL Server 2014:
	- Download "SQL Server 2014 Express with Tools 64 Bit" from "https://msdn.microsoft.com/en-us/sqlserver2014express.aspx" (Express with Tools (SQLEXPRWT)).
	- During the installation process, set the sql instance/server name to "SQLExpress".
- Internet Information Services Version 8.5:
	- Install instructions -> "https://technet.microsoft.com/en-us/library/ms143748(v=sql.90).aspx".
	- Please make sure you install the "Application Development Features":
		- In "Turn windows features on or off"
		- In the features window, Click: "Internet Information Services"
		- Click: "World Wide Web Services"
		- Click: "Application Development Features"
		- Check (enable) the features. I checked all but CGI."

Setup Instructions:

- Publish "WebApplication" APS.net MVC application on IIS server:
	- Open "Internet Information Services (IIS) Manager" application.
    - Right click on "Default Web Site" and select "Add Application...".
    - On the "Add Application" dialog set "Alias:" to "contacts.
    - Click the "..." to set the "Physical path:" to "C:\inetpub\wwwroot\contacts", make the folder "contacts" under "C:\inetpub\wwwroot".
    - Open the "Candidate\WebService\WebService\WebService.sln" Visual Studio solution.
    - Right click on "WebApplication" project and select "Publish...".
    - Publish the "WebApplication" to "C:\inetpub\wwwroot\contacts" folder.

- Connect the "WebApplication" and "UnitTests" to SQL Server instance:
	- Open Visual Studio and open the window "SQL Server Object Explorer".
	- Right click on the window and select "Add SQL Server...".
	- On "Server name:" combobox "<browse for more..>".
	- Find and select the SQL Server Local Server.
	- The SQL server connection strings of the projects are at "WebApplication/Web.config/<configuration><connectionStrings>" and "UnitTests/App.config<configuration>/<connectionStrings>".

SQLExpress

sa -> pass

SQL SErver Object Explorer/Add SQL Server.../ServerName:Browse/SQLServerExpress/Autentication:Windows Autentication

SQLServerConnection/Type, DataSource:MicrosoftSQLServer 

Login failed for user \u0027IIS APPPOOL\\DefaultAppPool\u0027

- It is necessary to give access permissions to the sqlserver and database to the IIS user, In Microsoft Mysql Managemente Studio add "IIS APPPOOL\DefaultAppPool" user and give the required permissions/user roles to access the server and db.

References:

https://msdn.microsoft.com/en-us/library/dd936243.aspx
http://plugins.jquery.com/soap/
https://msdn.microsoft.com/en-us/library/ff649690.aspx
http://blog.falafel.com/implement-step-step-generic-repository-pattern-c/
http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
http://www.codeproject.com/Articles/29271/Design-pattern-Inversion-of-control-and-Dependency
http://www.codeproject.com/Articles/29444/Design-Pattern-IOC-and-DI
http://www.codeproject.com/Articles/135114/Dependency-Injection-with-StructureMap-in-ASP-NET

