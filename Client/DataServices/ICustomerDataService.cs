using LabEntity.Shared;

namespace BlazorDemoPart2.Client.DataServices
{
    public interface ICustomerDataService
    {
        Task<IEnumerable<Customer>> GetAllCustomers(bool refreshRequired = false);
        Task<Customer> GetCustomerDetails(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
    }
}
