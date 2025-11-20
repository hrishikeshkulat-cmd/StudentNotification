🌟 Student Notification System (ASP.NET Core MVC + EF Core)

A simple, beginner-friendly ASP.NET Core MVC project that manages Students and their Notifications.
Built to learn MVC fundamentals, CRUD operations, routing, layouts, and Entity Framework Core — all with clean, understandable code.

🚀 Features
✔ Students Module

Add new students

View all students

Edit student details

Delete students

Fully async EF Core CRUD

✔ Notifications Module

Create notifications

View all notifications

Each notification belongs to a student (via StudentId)

Uses EF Core relationships + Include()

Simple, beginner-friendly controller design

✔ Cinematic UI

Custom _Layout.cshtml with a Midnight Blue Cinematic Theme

Glassmorphism panels

Smooth animations

Modern icons (FontAwesome)

🛠 Tech Stack

ASP.NET Core MVC 8

Entity Framework Core

SQL Server (LocalDB / Express)

Bootstrap 5

FontAwesome Icons

C# async/await

Razor Views

📂 Project Structure
StudentNotification/
│
├── Controllers/
│   ├── StudentsController.cs
│   └── NotificationsController.cs
│
├── Models/
│   ├── Student.cs
│   └── Notification.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Views/
│   ├── Students/
│   ├── Notifications/
│   ├── Shared/
│   │    └── _Layout.cshtml (Cinematic UI)
│
└── appsettings.json

🎓 What I Learned

This project helped me understand:

✔ MVC Architecture

How controllers handle requests

How views display data

How models store data

✔ Routing

Why URLs map to controllers

How ControllerName/ActionName works

✔ EF Core Basics

DbContext

DbSet

Migrations

Add / Update / Delete / Read

Include() for relational data

✔ Razor Views

Passing data from controller to view

Strongly typed models

Bootstrap UI components

✔ async / await

Why database calls should be async

Understanding non-blocking operations

🏗 Database Setup

Run these commands in Package Manager Console:

Add-Migration InitialCreate
Update-Database


This creates the Students and Notifications tables.

▶️ How to Run the Project

Clone the repo

Open solution in Visual Studio

Update connection string in appsettings.json

Run database migrations

Press F5

🌈 UI Preview (Cinematic Mode)

Dark Midnight Blue gradient

Animated background

Glass panels

Smooth transitions

Modern navigation icons

🔮 Future Enhancements

Auto-notification when a student is created

Dropdown list for selecting student

Delete notifications

Better UI cards for notifications

Login system

Role-based dashboard

💜 Author

Hrishi Kulat
Full-Stack .NET Developer (In Progress)
Learning step-by-step with clarity & simplicity.
