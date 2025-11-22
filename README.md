# 🎁 BabyThree Blindbox Store

**BabyThree** is an online blindbox (mystery box) e-commerce website inspired by Popmart.  
It is built with **ASP.NET Core (.NET 8)** for the backend and **ReactJS** for the frontend.  
The project supports **user authentication**, **product & inventory management**, **shopping cart**, **orders**, **reviews**, and **AI Recommendation Module** 
---

## 🚀 Main Features

### 👤 User Features
- Register / Login / Role-based authentication (User, Admin)
- View and edit personal information, purchase history
- Add products to cart and checkout
- Review and rate products

### 🛒 Product & Order Management
- CRUD operations for products, categories, and inventory
- Manage orders and track their status (Pending → Shipped → Completed)
- Inventory management via `InventoryRecords`

### ⚙️ Admin Dashboard
- Manage users, products, and categories
- View analytics such as total users, orders, and revenue
- Category supports hierarchy using `ParentId`

---

## 🧱 Architecture & Technologies

| Layer | Technology |
|-------|-------------|
| Backend | ASP.NET Core Web API (.NET 8) |
| ORM | Entity Framework Core (Code First with SQL Server) |
| Frontend | ReactJS + TailwindCSS |
| Database | Microsoft SQL Server |
| Authentication | ASP.NET Identity / JWT |
| Version Control | Git + GitHub |

---

## 🗃️ Database Overview

**Main Tables:**
- `Users` — account information and roles  
- `Products` — product data (slug, description, price, discount, images)  
- `Categories` — supports multi-level structure via `ParentId`  
- `Carts`, `CartItems` — shopping cart system  
- `Orders`, `OrderDetails` — order tracking  
- `InventoryRecords` — inventory control  
- `Reviews` — product feedback and ratings  
- `EventLog`, `UserEvent`, `ProductEmbedding`, `Recommendation` — for AI-based recommendation module

---

## 🧩 Setup & Run

### 1️⃣ Clone the repository
```bash
git clone https://github.com/trngchnii/Shopping-Practice.git
cd Shopping-Practice
