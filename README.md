# CustomerManagementSolution

This project captures customer biographic data and flight details prior to departure. It also sends notification emails for API and PNRGOV compliance.

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
