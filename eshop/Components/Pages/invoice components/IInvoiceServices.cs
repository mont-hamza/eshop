using eshop.Data.Entities;

namespace eshop.Components.Pages.invoice_components
{
    public interface IInvoiceServices
    {
        Task <Invoice> GetInvoicebyId(Guid id);
        Task <List<Invoice>> GetInvoices();
        Task <Invoice> Save(Invoice invoice);
        Task <Invoice> UpdateInvoice(Invoice invoice);
        Task DeleteAsync(Invoice invoice);

    }
}