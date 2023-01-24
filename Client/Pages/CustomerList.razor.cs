

using BlazorDemoPart2.Client.DataServices;
using BlazorDemoPart2.Client.Models;
using LabEntity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoPart2.Client.Pages
{
    public partial class CustomerList
    {

        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }
        public List<Customer>? Customers { get; set; } = default!;
        private Customer? _selectedCustomer;

        protected override async Task OnInitializedAsync()
        {
            // Customers = DummyDataService.Customers;
            Customers = (await CustomerDataService.GetAllCustomers()).ToList();


        }
                

        public void ShowCustomerPopup(Customer selectedCustomer)
        {
            _selectedCustomer = selectedCustomer;
        }

        
    }
}
