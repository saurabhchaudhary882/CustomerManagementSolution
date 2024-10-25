using CustomerManagementAPI.Context;
using CustomerManagementAPI.Models;
using CustomerManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace CustomerManagementTest
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _customerService;
        private readonly CustomerDbContext _dbContext;
        private readonly Mock<ILogger<CustomerService>> _mockLogger;

        public CustomerServiceTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
        .Options;

            _dbContext = new CustomerDbContext(options);
            _mockLogger = new Mock<ILogger<CustomerService>>();

            _customerService = new CustomerService(_dbContext, _mockLogger.Object);
        }

        [Fact]
        public async Task GetCustomersAsync_Should_Return_All_Customers()
        {
            // Arrange
            _dbContext.Customers.AddRange(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Saurabh",
                    LastName = "Chaudhary",
                    Email = "saurabhchaudhary882@gmail.com",
                    PhoneNumber = "07407077950",
                    Address = "123 Main St",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Gender = "Male"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Pinewood",
                    LastName = "Tech",
                    Email = "pinewood@example.com",
                    PhoneNumber = "0987654321",
                    Address = "456 Oak Ave",
                    DateOfBirth = new DateTime(1992, 2, 2),
                    Gender = "Other"
                }
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _customerService.GetCustomersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task GetCustomerByIdAsync_Should_Return_Customer_By_Id()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Jake",
                LastName = "Causer",
                Email = "jake.causer@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male"
            };
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _customerService.GetCustomerByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jake", result.FirstName);
            Assert.Equal("Causer", result.LastName);

            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task AddCustomerAsync_Should_Add_Customer_And_Return_It()
        {
            // Arrange
            var newCustomer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male"
            };

            // Act
            var result = await _customerService.AddCustomerAsync(newCustomer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);

            var customerInDb = await _dbContext.Customers.FindAsync(result.Id);
            Assert.NotNull(customerInDb);

            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task UpdateCustomerAsync_Should_Update_Existing_Customer()
        {
            // Arrange
            var existingCustomer = new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male"
            };
            _dbContext.Customers.Add(existingCustomer);
            await _dbContext.SaveChangesAsync();

            // Update the customer
            existingCustomer.LastName = "Smith";

            // Act
            var result = await _customerService.UpdateCustomerAsync(existingCustomer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Smith", result.LastName);

            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task DeleteCustomerAsync_Should_Delete_Customer_And_Return_True()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male"
            };
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _customerService.DeleteCustomerAsync(1);

            // Assert
            Assert.True(result);
            var deletedCustomer = await _dbContext.Customers.FindAsync(1);
            Assert.Null(deletedCustomer);

            _dbContext.Database.EnsureDeleted();
        }
    }
}