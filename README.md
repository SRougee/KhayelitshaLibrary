# Khayelitsha Community Library Management System

## MDB622 – Formative Assessment 2

This project is a C# Windows Forms application for managing the Khayelitsha Community Library.

The application uses:

- C#
- Windows Forms
- Microsoft SQL Server
- Microsoft.Data.SqlClient
- System.Configuration.ConfigurationManager

---

# 1. Requirements

Before opening the project, make sure the following are installed:

1. Visual Studio with **Desktop development with .NET** installed.
2. Microsoft SQL Server.
3. SQL Server Management Studio (SSMS) is recommended for running the database setup script.
4. The supplied Visual Studio solution/project files.
5. The supplied SQL database setup script.

---

# 2. Open the Project

1. Extract the complete project ZIP file.
2. Open the `.sln` solution file in Visual Studio.
3. Allow Visual Studio to restore any existing NuGet packages.
4. Build the solution using:

**Build → Build Solution**

or press:

`Ctrl + Shift + B`

---

# 3. Install the Required NuGet Packages

The application requires the following NuGet packages:

- `Microsoft.Data.SqlClient`
- `System.Configuration.ConfigurationManager`

## Option A – Visual Studio Package Manager Console

In Visual Studio:

**Tools → NuGet Package Manager → Package Manager Console**

Run these commands:

```powershell
Install-Package Microsoft.Data.SqlClient
Install-Package System.Configuration.ConfigurationManager
```

After installation, rebuild the solution:

```text
Build → Rebuild Solution
```

## Option B – NuGet Package Manager GUI

1. Right-click the project in **Solution Explorer**.
2. Select **Manage NuGet Packages**.
3. Select the **Browse** tab.
4. Search for:
   - `Microsoft.Data.SqlClient`
   - `System.Configuration.ConfigurationManager`
5. Install both packages.
6. Rebuild the project.

---

# 4. Create the SQL Server Database

The project is supplied with the SQL setup script used to create the database.

The database is called:

`KhayelitshaLibraryDB`

The SQL script creates the required database structure, including:

- `Member`
- `BookTitle`
- `BookCopy`
- `Staff`
- `Loan`

It also creates the required primary keys, foreign keys, constraints and sample data.

## Run the supplied SQL setup script

1. Open **SQL Server Management Studio (SSMS)**.
2. Connect to the SQL Server instance.
3. Open the supplied SQL setup file, for example:

`KhayelitshaLibraryDB.sql`

4. Execute the complete script by clicking **Execute** or pressing:

`F5`

5. Wait for the script to complete successfully.

The script should create the database and populate it with the sample records supplied for the practical project.

---

# 5. Verify the Database

In SSMS, refresh:

**Databases**

You should see:

`KhayelitshaLibraryDB`

Expand:

`KhayelitshaLibraryDB → Tables`

The following tables should be present:

- `dbo.Member`
- `dbo.BookTitle`
- `dbo.BookCopy`
- `dbo.Staff`
- `dbo.Loan`

The supplied setup script contains the sample data required for the project.

The expected sample-data structure is:

- 5 members
- 5 book titles
- 8 book copies
- 3 staff members
- 5 loan records

---

# 6. Configure the Application Connection

The application uses the connection string stored in `App.config`.

The connection string used for the completed development setup is:

```xml
<connectionStrings>
  <add name="LibraryConnection"
       connectionString="Server=DESKTOP-4C402HC;Database=KhayelitshaLibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

If the SQL Server instance on another computer has a different server name, change:

```text
DESKTOP-4C402HC
```

to the correct SQL Server instance name.

The database name must remain:

```text
KhayelitshaLibraryDB
```

unless the database setup script and application connection string are changed together.

---

# 7. Check App.config

The project should contain an `App.config` file similar to:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="LibraryConnection"
         connectionString="Server=DESKTOP-4C402HC;Database=KhayelitshaLibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
         providerName="Microsoft.Data.SqlClient" />
  </connectionStrings>
</configuration>
```

Make sure the connection-string name is:

```text
LibraryConnection
```

This name must match the name used by `DatabaseHelper.cs`.

---

# 8. Build and Run the Application

After installing the packages and creating the database:

1. Save all files.
2. In Visual Studio select:

**Build → Rebuild Solution**

3. If the build succeeds, press:

`F5`

or select:

**Debug → Start Without Debugging**

The application should open at the main Dashboard.

---

# 9. Test the Database Connection

The application should connect to:

```text
KhayelitshaLibraryDB
```

If the application displays database-related errors, check:

1. SQL Server is running.
2. `KhayelitshaLibraryDB` exists.
3. The server name in `App.config` is correct.
4. The `Microsoft.Data.SqlClient` package is installed.
5. The `System.Configuration.ConfigurationManager` package is installed.
6. The database setup script completed successfully.

---

# 10. Application Modules

The completed application contains the following main functions.

## Dashboard

Provides access to:

- Member Management
- Book Management
- Loan Management
- Reports

## Member Management

Allows the user to:

- Add members
- View members
- Update members
- Delete members
- Search members
- Clear the form

## Book Management

Allows the user to:

- Add book titles
- Update book titles
- Delete book titles
- Add physical book copies
- Update book copies
- Delete book copies
- View copy status

The `BookTitle` table uses:

```text
PublishedYear
```

as the publication-year column.

## Loan Management

Allows the user to:

- Select a member
- Select an available book copy
- Select staff
- Issue a book
- Return a book
- View available books
- View current loans

When a book is issued, its copy status changes to:

```text
On Loan
```

When it is returned, its status changes back to:

```text
Available
```

Historical loan records are retained.

## Reports

The Reports module provides:

- Member search
- Book search
- Loan filtering
- Overdue-book report
- Loans-per-member summary

---

# 11. Troubleshooting

## Error: Microsoft.Data.SqlClient could not be found

Open:

**Tools → NuGet Package Manager → Package Manager Console**

Run:

```powershell
Install-Package Microsoft.Data.SqlClient
```

Then rebuild the solution.

---

## Error: ConfigurationManager could not be found

Run:

```powershell
Install-Package System.Configuration.ConfigurationManager
```

Then rebuild the solution.

---

## Error: Cannot open database "KhayelitshaLibraryDB"

Check that:

- SQL Server is running.
- The database setup script was executed.
- The database is named `KhayelitshaLibraryDB`.
- The server name in `App.config` is correct.

---

## Error: Login failed

The supplied connection uses Windows Authentication:

```text
Trusted_Connection=True
```

Make sure the Windows user running the application has access to the SQL Server database.

---

## Error: Invalid object name

This normally means the database setup script has not been executed correctly.

Open SSMS and verify that these tables exist:

```text
Member
BookTitle
BookCopy
Staff
Loan
```

---

# 12. Recommended Installation Order

For a clean installation, follow this order:

1. Install Visual Studio.
2. Install SQL Server and SSMS.
3. Extract the project.
4. Open the Visual Studio solution.
5. Install the required NuGet packages.
6. Run the supplied `KhayelitshaLibraryDB.sql` database setup script in SSMS.
7. Verify the database and tables.
8. Check the `App.config` connection string.
9. Rebuild the Visual Studio solution.
10. Run the application.

---

# 13. Project Files

The final submission should contain:

```text
# 13. Project Files

The completed project contains the following main files and folders:

```text
KhayelitshaLibrary/
│
├── bin/
├── obj/
├── packages/
├── Properties/
├── README.md
│
├── .gitattributes
├── .gitignore
├── App.config
├── DatabaseHelper.cs
├── KhayelitshaLibrary.csproj
├── KhayelitshaLibrary.slnx
├── KhayelitshaLibraryDB.sql
├── packages.config
├── Program.cs
│
├── MainForm.cs
├── MainForm.Designer.cs
├── MainForm.resx
│
├── MemberForm.cs
├── MemberForm.Designer.cs
├── MemberForm.resx
│
├── BookForm.cs
├── BookForm.Designer.cs
├── BookForm.resx
│
├── LoanForm.cs
├── LoanForm.Designer.cs
├── LoanForm.resx
│
├── ReportsForm.cs
├── ReportsForm.Designer.cs
└── ReportsForm.resx
```