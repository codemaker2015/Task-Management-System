1. How to attach database in "SQL Server Management Studio Express".
	1. Expand LOCALHOST\SQLEXPRESS
	2. Right click on Databases
	3. Click Attach
	4. Click ADD button
	5. Locat the file "TaskManagementDB.mdf"
	6. Click on OK button
	7. Database is attached.

2. How to run the web application
	1. Run "Microsoft Visual Studio 2005"
	2. File --> Open --> Website
	3. Locate folder "TaskManagement" .Dont open it. Only select the folder
	4. click open
	5. View --> Solution Explorer
	6. select "LogInUI.aspx" under "UI" folder.
	7. Set this page as starting page.
	8. Build the solution.
	9. Debug

3. How to locate database for Crystel Reports
	1. Open a report. Eg."ReportEmployee.rpt"
	2. On field explorer right click on Database Fields select Database Expert
	   that is "field explorer" --> Database Fields(right click) --> Database Expert
	3. Create New Connection --> OLE DB(ADO)
	4. Select "Microsoft OLE DB Provider for SQL Server"
	5. Click on "Next"
	6. Check on Integrated Security. User ID and Password fild will become read only
	7. On server field "yourComputerName\SQLEXPRESS". E.g. "Codemaker\SQLEXPRESS".
	   In my computer "LOCALHOST\SQLEXPRESS" is not working
	8. Click on Database DDL all existing database in SQLEXPRESS will appear.
	   Select "TaskManagementDB".
	9. Click "Next" --> Finish --> Ok.
	10.Repate this for every report.
	11.Now report will work proprtly.



4. Where to change
	1. No need to change in webconfig file. I place the server name common for all computer
	   "server = localhost\SQLEXPRESS"
	2. Locate the database in every Crystel Report.