# CustomerManagementSolution

This is a self-contained Customer Management solution built using ASP.NET Core for both the front-end and back-end. The application enables basic CRUD (Create, Read, Update, Delete) operations for managing customer data, following a clean separation of concerns between the UI and API layers.

## Key Features:

- Add Customers: Users can create new customer records by entering biographic data (such as name, email, and contact details).
- Edit Customers: Existing customer information can be updated via an easy-to-use form.
- Delete Customers: Customers can be deleted from the database or data store.
- Customer Listing: A simple UI displays a list of all customers with options to edit or delete them.

## Getting Started

Follow these instructions to get the project up and running on your local machine for development and testing.

### Prerequisites

To run this project, you will need the following software:

- **Microsoft Visual Studio 2022**
- **ASP.NET Core 8.0** (with necessary extensions)
- **Microsoft SQL Server** (Developer/Express)
- **SQL Server Management Studio (SSMS)**

For version control and repository access, use:

- **Git** or preferred third-party Git UI tools like SourceTree or GitHub Desktop.

Repository Link:

- **GitHub**: [https://github.com/saurabhchaudhary882/CustomerManagementSolution.git](https://github.com/saurabhchaudhary882/CustomerManagementSolution.git)

### Installing

1. **Clone the repository**:
   ```bash
   git clone https://github.com/saurabhchaudhary882/CustomerManagementSolution.git
   ```

2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Set up the database**:
   - Run the following command to update the database:
     ```bash
     dotnet ef database update --project CustomerManagementAPI
     ```

4. **Run the API and UI**:
   - Launch the Web API and UI in Visual Studio or via CLI:
     ```bash
     dotnet run --project CustomerManagementAPI
     dotnet run --project CustomerManagementUI
     ```

## Built With

- **ASP.NET Core 8.0**
- **Entity Framework Core** (Code-First)
- **xUnit** (for testing)
- **SQL Server**

## Contributors

- **saurabhchaudhary882@gmail.com**
