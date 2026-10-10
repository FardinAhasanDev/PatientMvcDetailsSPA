<div align="center">

# 🏥 PatientCare Pro

### Patient Management System | ASP.NET MVC 5 & Entity Framework 6

A database-driven healthcare management application for organizing **patients, doctors, prescriptions, and user roles** through a responsive web interface with AJAX-powered interactions.

[![Repository](https://img.shields.io/badge/GitHub-View_Repository-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/FardinAhasanDev/PatientMvcDetailsSPA)
[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC_5-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/aspnet/mvc/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

</div>

---

## 📖 About the Project

**PatientCare Pro** (`PatientMvcDetailsSPA`) is an **ASP.NET MVC 5** web application built to demonstrate practical patient record management, relational data modeling, and authenticated administrative workflows.

The application combines **Razor views** with **jQuery/AJAX** and **Bootstrap modals** to provide SPA-like interactions for patient operations without requiring a separate JavaScript SPA framework. It uses **Entity Framework 6 Code First** and **SQL Server** for data persistence.

## ✨ Key Features

### 👤 Patient Management

- Create, view, edit, and delete patient records
- Record admission dates, contact numbers, registration fees, and enrollment status
- Assign a doctor to each patient
- Upload patient profile images, with a fallback image when none is provided
- Search the patient table on the client side
- Add and edit patients through AJAX-loaded modal forms

### 💊 Prescription Management

- Add multiple prescriptions to a patient record
- Record medicine names and treatment durations
- Dynamically add or remove prescription rows in patient forms
- Update existing prescriptions when editing patient details

### 🩺 Doctor Management

- Create, view, update, and delete doctor records
- Associate patients with doctors
- Restrict doctor deletion to users with the **Admin** role

### 🔐 Accounts & Administration

- User sign-up, login, and logout using ASP.NET Forms Authentication
- Role-based authorization using a custom role provider
- Admin-only role creation, user listing, and role assignment
- Admin-only user management pages

### 📊 Dashboard & Interface

- Patient summary cards for total, enrolled, and non-enrolled patients
- Doctor count based on patient assignments
- Responsive Razor pages styled with Bootstrap
- AJAX-based patient create, update, and delete actions

## 🧰 Tech Stack

**Languages & Web**

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat-square&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat-square&logo=css3&logoColor=white)

**Frameworks & UI**

![ASP.NET MVC 5](https://img.shields.io/badge/ASP.NET_MVC-5.2.9-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![.NET Framework 4.8](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Razor](https://img.shields.io/badge/Razor-Views-512BD4?style=flat-square)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3.5-7952B3?style=flat-square&logo=bootstrap&logoColor=white)
![jQuery](https://img.shields.io/badge/jQuery-3.7.1-0769AD?style=flat-square&logo=jquery&logoColor=white)
![AJAX](https://img.shields.io/badge/AJAX-Partial_Views-007ACC?style=flat-square)

**Database & Data Access**

![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![Entity Framework 6](https://img.shields.io/badge/Entity_Framework-6.4.4-512BD4?style=flat-square)
![Code First](https://img.shields.io/badge/EF-Code_First_Migrations-4479A1?style=flat-square)

**Development Tools**

![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat-square&logo=visualstudio&logoColor=white)
![NuGet](https://img.shields.io/badge/NuGet-004880?style=flat-square&logo=nuget&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=flat-square&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat-square&logo=github&logoColor=white)

## 🧱 Application Structure

The project follows the **Model–View–Controller (MVC)** pattern with separate data access, view models, and Entity Framework migrations.

```text
PatientMvcDetailsSPA/
├── PatientMvcDetailsSPA.sln
└── PatientMvcDetailsSPA/
    ├── App_Start/           # MVC route configuration
    ├── Controllers/         # Account, Administrator, Doctors, Patients, Home
    ├── DAL/                 # PatientDbContext
    ├── Models/              # Patient, Doctor, Prescription, user/role models
    ├── ViewModels/          # Patient and authorization view models
    ├── Views/               # Razor pages and reusable partial views
    ├── Migrations/          # Entity Framework Code First migrations
    ├── Content/             # CSS and Bootstrap styles
    ├── Scripts/             # jQuery and Bootstrap scripts
    ├── images/              # Patient image assets
    ├── Web.config           # Application and database configuration
    └── packages.config      # NuGet package versions
```

### 🗃️ Data Relationships

- **Doctor → Patients:** One doctor can be associated with multiple patients.
- **Patient → Prescriptions:** One patient can have multiple prescriptions.
- **Users ↔ Roles:** User-role assignments are maintained through a linking table.

## ⚙️ Getting Started

### Prerequisites

- **Windows** with **Visual Studio** and ASP.NET/.NET Framework web development support
- **.NET Framework 4.8** developer tools
- **SQL Server** (or a compatible SQL Server LocalDB setup)
- **NuGet Package Manager**

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/FardinAhasanDev/PatientMvcDetailsSPA.git
cd PatientMvcDetailsSPA
```

**2. Open the solution**

Open `PatientMvcDetailsSPA.sln` in Visual Studio.

**3. Restore dependencies**

Restore the NuGet packages referenced by `packages.config` (Visual Studio may prompt you automatically).

**4. Configure SQL Server**

Open `PatientMvcDetailsSPA/Web.config` and update the connection string named **`PatientDbContext`** for your local SQL Server instance. Keep database credentials out of version control.

**5. Apply Entity Framework migrations**

In Visual Studio, open **Tools → NuGet Package Manager → Package Manager Console** and run:

```powershell
Update-Database
```

The existing migration configuration includes sample doctors, roles, and a demonstration account. Review and secure any seeded account before using the application beyond local development.

**6. Run the application**

Build the solution and start it with **IIS Express** from Visual Studio. Sign in to access the patient and doctor management pages.

## 🎯 What This Project Demonstrates

- Building a relational CRUD application with **ASP.NET MVC 5**
- Using **Entity Framework 6** for database access and migrations
- Handling one-to-many relationships and dynamic child records
- Improving server-rendered workflows with **AJAX and partial views**
- Applying **Forms Authentication** and role-based page authorization
- Organizing a traditional .NET Framework application into MVC layers

## 🔭 Possible Enhancements

- Secure password hashing and stronger account management
- Server-side pagination, filtering, and sorting
- Improved validation and error handling for AJAX requests
- Appointment scheduling and longitudinal patient history
- Automated tests and deployment configuration

> **Development note:** This repository is a learning/portfolio project, not a production-ready clinical system. The current authentication code compares stored passwords directly, and the migration seed includes a demo account. Replace this with secure password hashing, remove default credentials, and review authorization, data privacy, and file-upload validation before any real-world deployment. Do not use real patient data in a demo environment.

## 👨‍💻 Author

**Fardin Ahasan** — Full-Stack Developer

[![GitHub Profile](https://img.shields.io/badge/GitHub-FardinAhasanDev-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/FardinAhasanDev)

[**Explore the source code →**](https://github.com/FardinAhasanDev/PatientMvcDetailsSPA)

---

<div align="center">

*Thanks for checking out PatientCare Pro! ⭐ If you find the project useful, consider starring the repository.*

</div>
