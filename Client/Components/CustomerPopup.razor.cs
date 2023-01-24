using LabEntity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoPart2.Client.Components
{
    public partial class CustomerPopup
    {
        private Customer? _customer;

        [Parameter]
        public Customer? Customer { get; set; }

        protected override void OnParametersSet()
        {
            _customer = Customer;

        }

        public void Close()
        {
            _customer = null;
        }
    }
}
