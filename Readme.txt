Development Environment:

- Windows 8.1 64 bits.
- Visual Studio Community 2013 Version 12.0.
- SQL Server 2014:
	- Download "SQL Server 2014 Express with Tools 64 Bit" from "https://msdn.microsoft.com/en-us/sqlserver2014express.aspx" (Express with Tools (SQLEXPRWT)).
	- During the installation process, set the sql instance/server name to "SQLExpress".
- Internet Information Services (IIS) Version 8.5:
	- Install instructions -> "https://technet.microsoft.com/en-us/library/ms143748(v=sql.90).aspx".
	- Please make sure you install the "Application Development Features":
		- In "Turn windows features on or off"
		- In the features window, Click: "Internet Information Services"
		- Click: "World Wide Web Services"
		- Click: "Application Development Features"
		- Check (enable) the features. I checked all but CGI."

Setup Instructions:

- Connect the "WebApplication" and "UnitTests" to SQL Server instance:
	- Open Visual Studio and then open the "SQL Server Object Explorer" window.
	- Right click on the "SQL Server Object Explorer" window and select "Add SQL Server...".
	- Click on the "Server name:" combobox and select "<browse for more..>".
	- Find and select the SQL Server Local Server.
	- The SQL server connection strings of the projects are at "WebApplication/Web.config/<configuration><connectionStrings>" and "UnitTests/App.config/<configuration>/<connectionStrings>.

- Run the Unit Tests:
	- Open the Visual Studio and then open the "Test Explorer" window, it is at the menu option "Test/Window/TestExplorer".
	- Click "Run All" button.

- Publish "WebApplication" APS.net MVC application on IIS server:
	- Open "Internet Information Services (IIS) Manager" application.
    - Right click on "Default Web Site" and select "Add Application...".
    - On the "Add Application" dialog, set "Alias:" as "contacts".
    - Click the "..." to set the "Physical path:" to "C:\inetpub\wwwroot\contacts", you'll need to make the folder "contacts" under "C:\inetpub\wwwroot".
    - Open the "Candidate\WebService\WebService\WebService.sln" Visual Studio solution.
    - Right click on "WebApplication" project and select "Publish...".
    - Publish the "WebApplication" to "C:\inetpub\wwwroot\contacts" folder.
    - Now the web service should be accessible at "http://localhost/contacts/" but there could be sql server connection issues.
    - if there are SQL server connection issues please edit "WebApplication/Web.config/<configuration><connectionStrings>" and "UnitTests/App.config<configuration>/<connectionStrings> as necessary to fix the connection issues.
    - I got the sql server connection issue "Login failed for user \u0027IIS APPPOOL\\DefaultAppPool\u0027", this happens because the IIS default user does not have permissions/user roles on the sql server instance to create/access the database, to fix the issue I did the following:
    	- In "Microsoft Mysql Managemente Studio" add "IIS APPPOOL\DefaultAppPool" user and give the required permissions/user roles to access the server and create/access the database ("Contacts" and "ContactsTestUnits" databases are automatically created by the entity framework in the SQL Server instance).

- Publish the "Mockup" web service client application.
	- Make a new folder at "C:\inetpub\wwwroot\mockup" and copy the content from "Candidate\Mockup" to the new folder.
	- Now the mockup application should be accessible at "http://localhost/mockup/" and should connect to the "http://localhost/contacts/" web service.
	- Also there is a file that automatically copies the content from "C:\inetpub\wwwroot\mockup" to "Candidate\Mockup" the file is at "Candidate\Scripts\PublishMockup.cmd", I had to edit the folder user permission on "C:\inetpub\wwwroot" to let the "PublishMockup.cmd" copy the content automatically.


