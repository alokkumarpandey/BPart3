using BlazorDemoPart2.Client.DataServices;
using LabEntity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoPart2.Client.Pages
{
    public partial class CustomerAddEdit
    {
        [Inject]
        public ICustomerDataService? CustomerDataService { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string? CustomerId { get; set; }

        public Customer Customer { get; set; } = new Customer();

        public List<Country> Countries { get; set; } = new List<Country>();

        protected bool Saved;
        protected string Message = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            int.TryParse(CustomerId, out var customerId);
            if (customerId == 0)
            {
                Customer = new Customer { CountryId = 1, BirthDate = DateTime.Now };
            }
            else
            {
                Customer = await CustomerDataService.GetCustomerDetails(customerId);
            }

        }
        protected async Task SaveValidSubmit()
        {
            if (Customer.CustomerId == 0)
            {
                var addedCustomer = await CustomerDataService.AddCustomer(Customer);
                if (addedCustomer != null)
                {
                    Message = "Customer added successfully.!!";
                    Saved = true;
                }
                else
                {
                    Message = "Please try again, some problem while saving";
                    Saved = false;
                }
            }
            else
            {
                await CustomerDataService.UpdateCustomer(Customer);
                Message = "Customer updated successfully.!!!";
                Saved = true;
            }
        }
        protected async Task HandleInvalidSubmit()
        {
            Message = "Validation errors. Please try again.!!";
        }
        protected async Task DeleteCustomer()
        {
            await CustomerDataService.DeleteCustomer(Customer.CustomerId);
            Message = "Deleted successfully!!!";
            Saved = true;
        }
        protected void NavigateToCustomerList()
        {
            NavigationManager.NavigateTo("/customerlist");
        }
    }
}
    

