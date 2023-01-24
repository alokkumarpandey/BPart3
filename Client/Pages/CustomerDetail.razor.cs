
using BlazorDemoPart2.Client.DataServices;
using BlazorDemoPart2.Client.Models;
using LabEntity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoPart2.Client.Pages
{
    public partial class CustomerDetail
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Parameter]
        public string CustomerId { get; set; } = "0";
        public Customer? Customer { get; set; } = new Customer();

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerDataService.GetCustomerDetails(Int32.Parse(CustomerId));
                //DummyDataService.Customers!.FirstOrDefault(e => e.CustomerId == Int32.Parse(CustomerId));
        }
    }
}
