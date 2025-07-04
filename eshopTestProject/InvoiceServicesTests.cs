using eshop.Components.Pages.customer_components;
using eshop.Components.Pages.invoice_components;
using eshop.Data;
using eshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace eshopTestProject
{
    public class InvoiceServicesTests
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
        public async Task GetInvoicesAsync_ShouldReturnEmptyList_WhenNoInvoicesExist()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new InvoiceServices(Factory);
            // Act
            var result = await services.GetInvoices();
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }// check

        [Fact]
        public async Task GetInvoiceByIdAsync_ShouldReturnInvoice_WhenInvoiceExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new InvoiceServices(Factory);
            var NewInvoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),

            };
            await services.Save(NewInvoice);
            // Act
            var result = await services.GetInvoicebyId(NewInvoice.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(NewInvoice.Id, result.Id);
        }// check

        [Fact]
        public async Task SaveInvoiceAsync_ShouldAddInvoice_WhenInvoiceIsValid()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new InvoiceServices(Factory);
            var NewInvoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),

            };
            // Act
            var result = await services.Save(NewInvoice);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(NewInvoice.Id, result.Id);
        }// check

        [Fact]
        public async Task DeleteInvoiceAsync_ShouldRemoveInvoice_WhenInvoiceExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new InvoiceServices(Factory);
            var NewInvoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                
            };
            await services.Save(NewInvoice);
            // Act
            await services.DeleteAsync(NewInvoice);
            // Assert
            var result = await services.GetInvoicebyId(NewInvoice.Id);
            Assert.Null(result); // Invoice should be deleted
        }// check

        [Fact]
        public async Task UpdateInvoiceAsync_ShouldUpdateInvoice_WhenInvoiceExists()
        {
            // Arrange
            var options = GetNewContextOption();
            var Factory = GetDbContextFactory(options);
            var services = new InvoiceServices(Factory);

            // Add a customer
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerName = "Original Name"
            };
            var context1 = Factory.CreateDbContext();
            context1.Customers.Add(customer);
            await context1.SaveChangesAsync();
            // Do not dispose context1 here

            // Add an invoice for that customer
            var existingInvoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                Customer = customer
            };
            var context2 = Factory.CreateDbContext();
            context2.Invoices.Add(existingInvoice);
            await context2.SaveChangesAsync();
            // Do not dispose context2 here

            // Prepare update
            var updatedCustomerName = "Updated Name";
            var updatedInvoice = new Invoice
            {
                Id = existingInvoice.Id,
                CustomerId = customer.Id,
                Customer = new Customer { CustomerName = updatedCustomerName }
            };

            // Act
            var result = await services.UpdateInvoice(updatedInvoice);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingInvoice.Id, result.Id);
            Assert.Equal(updatedCustomerName, result.Customer.CustomerName);
        }// check
    }
}
