
# 🍽️ Restaurant Management System (RMS)

A **Restaurant Management System** built with **.NET (Windows Forms / .NET Framework)** and **Microsoft SQL Server**, designed to manage daily restaurant operations efficiently.

This project is collaboration-ready and focuses on **clean business logic**, **CRUD operations**, and **real-world restaurant workflows**.

---

## 🎯 Project Objectives

- Centralize restaurant operations
- Apply real business logic
- Practice collaborative development on GitHub
- Build a scalable foundation for future extensions

---

## 🧠 Business Logic Overview

- Users authenticate and act based on roles
- Orders depend on menu availability and inventory
- Payments depend on completed orders
- Inventory updates automatically after sales

---

## 👤 User Authentication & Roles

### Roles
- **Admin**
- **Cashier**

### Features

- Secure login (hashed passwords)
- Role-based access control
- Activate / deactivate users


## 🧾 Clients Management (CRUD)

### Operations
- Create client
- View clients
- Update client information
- Delete client
- Search clients

---

## 👨‍🍳 Employees Management (CRUD)

### Operations
- Add employee
- View employees
- Update employee data
- Delete employee
- Assign employees to orders

---

## 🍔 Menu Items Management (CRUD)

### Features
- Product image support
- Buying price & selling price
- Category and preparation time
- Availability control

### Operations
- Create menu item
- Update menu item
- Delete menu item
- Enable / disable menu item
- Upload product image

---

## 🧂 Ingredients Management (CRUD)

### Operations
- Add ingredient
- Update ingredient
- Delete ingredient
- Define quantity and unit (g, kg, L, ml)

---

## 🔗 Menu ↔ Ingredients Mapping

### Operations
- Link ingredients to menu items
- Remove ingredient from menu item

---

## 📦 Inventory Management (CRUD)

### Operations
- Track ingredient stock
- Update quantities

---

## 🛒 Orders Management (CRUD + Workflow)

### Order Status
- Pending
- Preparing
- Completed
- Cancelled

### Operations
- Create order
- Assign client, employee, and table
- Add / remove menu items
- Update order status
- Add order notes
- Auto-calculate total amount
- View order history

---

## 💳 Payment Methods Management (CRUD)

### Operations
- Add payment method
- Update payment method
- Enable / disable payment method
- Delete payment method

---

## 💰 Payments Management (CRUD)

### Operations
- Create payment for an order
- Select payment method
- Add tips
## missing table 

CREATE TABLE ProductInventory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    ReorderLevel INT NOT NULL DEFAULT 0,
    LastUpdated DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_ProductInventory_MenuItems
        FOREIGN KEY (MenuItemId) REFERENCES MenuItems(Id)
);
GO


## 🚀 How to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/restaurant-management-system.git
