using LabEntity.Shared;
using System.Text;
using System.Text.Json;

namespace BlazorDemoPart2.Client.DataServices
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly HttpClient? _httpClient;

        public CustomerDataService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var customerJson =
                new StringContent(JsonSerializer.Serialize(customer),
                Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/customers", customerJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Customer>
                    (await response.Content.ReadAsStreamAsync());
            }

            return null;

        }
        public async Task UpdateCustomer(Customer customer)
        {
            var customerJson =
               new StringContent(JsonSerializer.Serialize(customer),
               Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/customers", customerJson);
        }

        public async Task DeleteCustomer(int customerId)
        {
            await _httpClient.DeleteAsync($"api/customers/{customerId}");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers(bool refreshRequired = false)
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>
                    (await _httpClient.GetStreamAsync($"api/customers"), 
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return list;
        }

        public async Task<Customer> GetCustomerDetails(int customerId)
        {
            return await JsonSerializer.DeserializeAsync<Customer>
                (await _httpClient.GetStreamAsync($"api/customers/{customerId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        
    }
}
