using eshop.Data.Entities;
using eshop.Data;
using Microsoft.EntityFrameworkCore;


namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceServices : IInvoiceServices
    {
        readonly IDbContextFactory<ApplicationDbContext>? _contextFactory;
        public InvoiceServices(IDbContextFactory<ApplicationDbContext>? contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<Invoice> GetInvoicebyId(Guid id)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _DbContext.Invoices
                .FirstOrDefaultAsync(i => i.Id == id);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
        public Task<List<Invoice>> GetInvoices()
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            return _DbContext.Invoices
                .Include(i => i.Customer) // <-- This line ensures Customer data is loaded
                .ToListAsync();
        }
        public async Task<Invoice> Save(Invoice invoice)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            _DbContext.Invoices.Add(invoice);
            await _DbContext.SaveChangesAsync();
            return invoice;
        }
        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
                throw new Exception("Database context is not available");

            var existingInvoice = await _DbContext.Invoices
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(i => i.Id == invoice.Id);

            if (existingInvoice == null)
                throw new Exception("Invoice not found");

            existingInvoice.CustomerId = invoice.CustomerId;

            // If you want to update the customer, ensure it's not null
            if (existingInvoice.Customer == null)
            {
                existingInvoice.Customer = await _DbContext.Customers.FindAsync(existingInvoice.CustomerId);
                if (existingInvoice.Customer == null)
                    throw new Exception("Customer not found");
            }

            existingInvoice.Customer.CustomerName = invoice.Customer?.CustomerName;

            await _DbContext.SaveChangesAsync();
            return existingInvoice;
        }
        public async Task DeleteAsync(Invoice invoice)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            _DbContext.Invoices.Remove(invoice);
            await _DbContext.SaveChangesAsync();

        }
        public async Task<List<Invoice>> GetInvoicesByCustomerId(Guid customerId)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
                return new List<Invoice>();

            return await _DbContext.Invoices
                .Where(i => i.CustomerId == customerId)
                .Include(i => i.Customer)
                .ToListAsync();
        }
    }
}
