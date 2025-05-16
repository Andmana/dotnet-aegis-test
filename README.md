# dotnet-aegis-test
# Technical Test – Junior .NET Developer

## Description

This project was developed as part of a technical evaluation for the **Junior .NET Developer** position. The application is built using **.NET Core** and provides functionality to **download reports in Excel and PDF formats** with a **simple custom layout**. The PDF export feature is implemented using **Rotativa.AspNetCore**.

---

## Features

- Export reports to **Excel (.xlsx)** format
- Export reports to **PDF (.pdf)** using **Rotativa**
- Custom simple layout for exported files
- Data loaded dynamically from **SQL Server** via **Stored Procedure with CTE**
- Clean architecture using **Repository Pattern** and **ADO.NET**
- No usage of any ORM (e.g., EF Core)

---

## Technologies Used

- [.NET Core](https://dotnet.microsoft.com/)
- ASP.NET Core MVC
- [Rotativa.AspNetCore](https://github.com/webgio/Rotativa.AspNetCore) – for PDF generation
- [EPPlus](https://github.com/EPPlusSoftware/EPPlus) – for Excel generation
- Razor Views for PDF formatting
- Microsoft SQL Server
- Stored Procedure + CTE
- ADO.NET (SqlConnection, SqlCommand, SqlDataReader)
- Repository Pattern Architecture

---
