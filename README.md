# TechFix API

TechFix is a .NET Web API application designed to manage inventory and supplier interactions for a technical repair shop. The API enables **TechFix users** to manage their stock, request quotations from suppliers, and view supplier inventories. Suppliers can add their inventory and respond to quotation requests.

## Table of Contents

- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

---

## Getting Started

To get a copy of the TechFix API up and running on your local machine, follow the instructions below.

---

## API Endpoints

### **TechFix Users**
- `GET /api/inventory`: View TechFix's current inventory.
- `POST /api/quote/request`: Request a quote from suppliers.
- `GET /api/suppliers`: View available suppliers and their inventories.

### **Suppliers**
- `POST /api/inventory`: Add items to the supplier's inventory.
- `POST /api/quote/respond`: Respond to a quote request from TechFix.

---

## Prerequisites

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) or higher
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other supported database
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for database access

---

## Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/techfix-api.git
    cd techfix-api
    ```

2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```

3. **Update database connection string** in `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Your SQL Server connection string here"
    }
    ```

4. **Apply database migrations**:
    ```bash
    dotnet ef database update
    ```

---

## Running the Application

1. Run the API locally:
    ```bash
    dotnet run
    ```

2. Access the API via:
    - `http://localhost:7135`
    - `https://localhost:7135` (for HTTPS)

---

## Project Structure

- **Controllers**: Handle HTTP requests and responses.
- **Models**: Define the data structure for TechFix users, suppliers, inventory, and quotes.
- **Services**: Business logic for managing TechFix inventory, supplier interactions, and quotations.
- **Data**: Entity Framework Core integration for database access.

---

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any improvements or suggestions.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
