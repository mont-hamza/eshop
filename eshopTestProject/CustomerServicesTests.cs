
using Microsoft.EntityFrameworkCore;
using Moq;
using eshop.Data;
using eshop.Data.Entities;
using eshop.Components.Pages.customer_components;


namespace eshopTestProject
{
    public class CustomerServicesTests
    {
        private IDbContextFactory<ApplicationDbContext> GetDbContextFactory(DbContextOptions<ApplicationDbContext> options)
        {        
            var MocFactory = new Mock<IDbContextFactory<ApplicationDbContext>>();
            MocFactory.Setup(x => x.CreateDbContext()).Returns(value: new ApplicationDbContext(options));
            return MocFactory.Object;
        }

        public static DbContextOptions<ApplicationDbContext> GetNewContextOption()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }
        //-----------------------------------------------------------------------------------------//


        [Fact]
        public async Task GetCustomersAsync_ShouldReturnACustomers_WhenCustomerExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new CustomerServices(Factory);
            var NewCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                CustomerEmail = "yrtr"
            };
            var SaveNewCustomer = await services.save(NewCustomer);

            // Act
            var result = await services.GetCustomerById(SaveNewCustomer.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SaveNewCustomer.CustomerName, result.CustomerName);

        }// check
        [Fact]
        public async Task GetCustomersAsync_ShouldReturnNull_WhenCustomerDoesnotExist() 
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new CustomerServices(Factory);
            var customerId = Guid.NewGuid();
            // Act
            var result = await services.GetCustomerById(customerId);
            // Assert
            Assert.Null(result);
        }// check

        [Fact]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomer_WhenCustomerExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new CustomerServices(Factory);
            var ExixtingCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                CustomerEmail = "gjsfsdfg"
            };

            var cf = Factory.CreateDbContext();
            cf.Customers.Add(ExixtingCustomer);
            await cf.SaveChangesAsync();
            var updatedCustomer = new Customer
            {
                Id = ExixtingCustomer.Id,
                CustomerName = "Updated Customer",
                CustomerEmail = "hgjjh"
            };

            // Act
            var result = await services.updateCustomer(updatedCustomer);
            // Assert
            var context = Factory.CreateDbContext();
            var savedCustomer = await context.Customers.FindAsync(ExixtingCustomer.Id);
            Assert.NotNull(savedCustomer);
            Assert.Equal(updatedCustomer.CustomerName, savedCustomer.CustomerName);
            Assert.Equal(updatedCustomer.CustomerEmail, savedCustomer.CustomerEmail);
        }// check

        [Fact]
        public async Task SaveCustomerAsync_ShouldSaveCustomer_WhenCustomerDoesnotExist()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);

            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                CustomerEmail = "dyteyt"
            };
            var Services = new CustomerServices(Factory);
            // Act
            var result = await Services.save(customer);

            // Assert
            using var context = new ApplicationDbContext(options);
            var savedCustomer = await context.Customers.FindAsync(customer.Id);
            Assert.NotNull(savedCustomer);
            Assert.Equal(customer.CustomerName, result.CustomerName);
        }//check

        [Fact]
        public async Task DeleteCustomerAsync_ShouldDeleteCustomer_WhenCustomerExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var customerId = Guid.NewGuid();
            var Exsistingcustomer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerName = "Test Customer",
                CustomerEmail = "gfhjf"
            };
            using (var cf= Factory.CreateDbContext())
            {
                cf.Customers.Add(Exsistingcustomer);
                await cf.SaveChangesAsync();
            }
            options = GetNewContextOption();
            Factory = GetDbContextFactory(options);
            var service = new CustomerServices(Factory);

            // Act
            await service.DeleteAsync(customerId);

            // Assert
            options = GetNewContextOption();
            Factory = GetDbContextFactory(options);
            using var context = Factory.CreateDbContext();
            var deletedCustomer = await context.Customers.FindAsync(customerId);
            Assert.Null(deletedCustomer);

        }// check

    }
}
    