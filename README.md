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

## 🙋 Author
Ian Gabriel C. Villame  
BSIT 3rd Year  

**SQLahan: Enrollment System Project for EDP**  

## ⚠️ Disclaimer
This application is developed solely for educational purposes as part of a school requirement. It is not intended for production use.
