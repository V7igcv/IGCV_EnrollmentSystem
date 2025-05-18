# SQLahan (EDP_WinProject102) - Enrollment System (C#/MySQL)

This is a Windows Forms application built using **C#** and **MySQL**, designed to manage student enrollments, tuition payments, instructors, schedules, and user accounts. It also features **Excel report generation** using Microsoft Office Interop.

## 📁 Project Structure
EDP_WinProject102/  
│  
├── reportTemplate/ (Excel templates for exported reports)  
├── generatedreports/ (Output folder for exported Excel files)  
├── DBManager.cs (Handles database connection)  
├── frmSystemUsers.cs (Form for managing system users)  
├── [Other Forms].cs Other modules (e.g. Payments, Instructors, Schedule, etc.))  
└── README.md (You're here!)

## 🖥️ Prerequisites

- **Visual Studio 2022 or later**
- **MYSQL Server Community Edition**
- **MySQL Workbench** and **.net Connector**
- **Microsoft Excel installed** (for report export to work)

## ⚙️ Setup Instructions

1. **Clone the repository:**
   git clone https://github.com/V7igcv/EDP_WinProject102.git
2. **Open the .sln file in Visual Studio.**
3. **Set up your MySQL database:**
   - Create a MySQL database named enrollment.
   - Import the provided SQL schema (Villame_SQLahan_Enrollment.sql)
4. **Update DB connection (if needed):**
   - In DBManager.cs, update:
     **private readonly string connectionString = "server=localhost; database=enrollment; uid=root; pwd=yourpassword;";**
5. **Ensure the following folders exist at the root of the project (same level as .sln):**
   - /reportTemplate/
   - /generatedreports/
6. **Ensure that the required Excel templates (e.g. systemUsers_template.xlsx) are inside /reportTemplate.**

## 📊 Notes  

- Click the "Export to MS Excel" button in any form (e.g. frmSystemUsers) to export the table to Excel.
- Templates are loaded from reportTemplate, and reports are saved to generatedreports.
- This project uses the MySql.Data library via NuGet for MySQL database connectivity. To ensure it's correctly installed:
  - In Visual Studio, open the Package Manager Console and run: **Install-Package MySql.Data**
  - Or go to Tools → NuGet Package Manager → Manage NuGet Packages for Solution, search for MySql.Data, and install it.

## 🧪 Features  

- Student Management
- Tuition Fee Management
- Instructor & Schedule Handling
- System User Management
- Excel Report Export using Templates
- MySQL Back-End Integration
- Basic UI Design with Validation

## ⚠️ Before You Install SQLahan (Download the Installer included in the project repository named "SQLahan_Installer.exe")
To ensure SQLahan works correctly, please follow these requirements before running the installer:  

✅ MySQL Setup Requirements  
1. Make sure MySQL Server 8.0 is installed on your laptop.
2. One of the following must be true:
   - MySQL is installed in the default folder:
     C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe
     OR
     C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysql.exe
   - OR the mysql.exe command is available in your system’s PATH
     (e.g., installed via MySQL Workbench and properly configured).
3. Your MySQL root account must:
   - Exist
   - use the password: villamecantos974
   - Not require additional authentication (no 2FA or socket auth)

💡 Why This Is Required
The installer will attempt to:
- Create a new database named enrollment
- Automatically import the SQL file Villame_SQLahan_Enrollment.sql

This step will fail if:
- MySQL is not found
- The password or user is incorrect
- MySQL is not installed or configured properly

✅ After Ensuring the Above:
- Run the installer SQLahan_Installer.exe.
- The database will be set up automatically.
- Launch the app from the desktop or Start Menu.

## 🙋 Author
Ian Gabriel C. Villame  
BSIT 3rd Year - Block B  

**SQLahan: Enrollment System Project for EDP**  

## ⚠️ Disclaimer
This application is developed solely for educational purposes as part of a school requirement. It is not intended for production use.
