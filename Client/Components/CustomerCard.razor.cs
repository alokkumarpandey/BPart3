using LabEntity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoPart2.Client.Components
{
    public partial class CustomerCard
    {

        [Parameter]
        public Customer Customer { get; set; } = default!;

        [Parameter]
        public EventCallback<Customer> CustomerQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public void NavigateToDetails(Customer selectedCustomer)
        {
            NavigationManager.NavigateTo($"/customerdetail/{selectedCustomer.CustomerId}");
        }
    }
}
