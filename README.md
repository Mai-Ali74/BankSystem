# Bank Management System 🏦

A modular, object-oriented Console Application built using C# and .NET. Designed as a practical implementation to consolidate and demonstrate advanced Object-Oriented Programming (OOP) concepts, this application simulates core banking operations while adhering to modern principles, clean layer division, and interface-driven design.

---

## 🌟 Key Features

### 👨‍💼 Admin Module

- **Customer Management:** Register new customers with unique IDs, contact details, and PIN setup.
- **Account Creation:** Open **Saving** or **Current** accounts for registered customers.
- **Status Control:** Dynamically update account states (**Active**, **Frozen**, or **Closed**).
- **Interest Application:** Calculate and apply interest for savings accounts.

### 👤 Customer Module

- **Deposits & Withdrawals:** Perform secure transactions backed by PIN authentication.
- **Fund Transfers:** Transfer money between active accounts with automatic validation.
- **Account Inquiry:** View current balances, owner details, and comprehensive transaction logs.

---

## 📂 Project Structure

```text
BankSystem/
│
├── Interfaces/
│   └── IBankService.cs          # Abstraction for banking operations
│
├── Models/
│   ├── Abstractions/            # Base abstract classes (User, Account)
│   ├── Entities/                # Domain entities (Customer, Employee, SavingAccount, etc.)
│   └── Enums/                   # System enums (AccountType, AccountStatus)
│
├── Services/                    # Main business logic implementation
│   └── BankService.cs
│
├── UI/                          # User interface interaction layer
│   ├── BankMenu.cs              # Main entry menu flow
│   ├── AdminMenu.cs             # Administrative operations flow
│   └── CustomerMenu.cs          # Customer banking interaction flow
│
└── Program.cs                   # Application entry point
```

---


## 🛠️ Technologies

- **Language: C# (.NET 9)**
- **Paradigm: Object-Oriented Programming (OOP)**
- **Architecture: Interface-based design & Layered structure**
- **Data Querying: LINQ**

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Any C# IDE:
  - [Visual Studio](https://visualstudio.microsoft.com/)
  - [Visual Studio Code](https://code.visualstudio.com/)
  - [JetBrains Rider](https://www.jetbrains.com/rider/)

### Installation & Execution

#### 1. Clone the Repository

```bash
git clone https://github.com/Mai-Ali74/BankSystem.git
```

#### 2. Navigate to the Project Directory

```bash
cd BankSystem
```

#### 3. Build the Application

```bash
dotnet build
```

#### 4. Run the Project

```bash
dotnet run
```


