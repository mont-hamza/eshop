using eshop.Data;
using eshop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Components.Pages.customer_components
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IDbContextFactory<ApplicationDbContext>? _contextFactory;

        public CustomerServices(IDbContextFactory<ApplicationDbContext>? contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<Customer>> GetCustomer()
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            return _DbContext.Customers
                .Include(c => c.Invoices)
                .ToListAsync();
        }
        public Task<Customer?> GetCustomerById(Guid id)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            return _DbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Customer> save(Customer customer)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            _DbContext.Customers.Add(customer);

            await _DbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> updateCustomer(Customer customer)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            var existingCustomer = await _DbContext.Customers.FindAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new Exception("Customer not found");
            }
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.CustomerEmail = customer.CustomerEmail;
            existingCustomer.CustomerPhone = customer.CustomerPhone;
            existingCustomer.CustomerAddress = customer.CustomerAddress;

            await _DbContext.SaveChangesAsync();
            return existingCustomer;
        }
        public async Task DeleteAsync(Guid id)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            var existingCustomer = _DbContext?.Customers.Find(id);
            if (existingCustomer != null)
            {
                _DbContext?.Customers.Remove(existingCustomer);
                await _DbContext.SaveChangesAsync();
            }
            

        }
    }
}