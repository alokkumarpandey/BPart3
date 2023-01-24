using LabEntity.Shared;

namespace BlazorDemoPart2.Client.Models
{
    public class DummyDataService
    {
        private static List<Customer>? _customers = default!;
        private static List<Country> _countries = default!;

        static DummyDataService()
        {
            //initialization of Customers
            _countries = InitializeDummyCountries();
            _customers = InitializeDummyCustomers();
        }

        public static List<Customer>? Customers
        {
            get
            {                
                return _customers;
            }
        }

        public static List<Country>? GetCountryList
        {
            get { return _countries; }
        }

        public static int TotalCountryCount
        {
            get { return _countries.Count; }
        }

        private static List<Customer> InitializeDummyCustomers()
        {
            var c1 = new Customer
            {
                Email = "Ram@gmail.com",
                CustomerId = 1,
                FirstName = "Ram",
                LastName = "Kumar",
                Country = _countries[0],
                CountryId = _countries[0].CountryId
            };

            var c2 = new Customer
            {
                Email = "suman@gmail.com",
                CustomerId = 2,
                FirstName = "Suman",
                LastName = "Kumar",
                Country = _countries[1],
                CountryId = _countries[1].CountryId
            };
            var c3 = new Customer
            {
                Email = "aman@gmail.com",
                CustomerId = 3,
                FirstName = "Aman",
                LastName = "Kumar",
                Country = _countries[1],
                CountryId = _countries[1].CountryId
            };

            return new List<Customer>() { c1, c2, c3 };
        }


        private static List<Country> InitializeDummyCountries()
        {
            return new List<Country>
            {
                new Country {CountryId = 1, Name = "Nepal"},
                new Country {CountryId = 2, Name = "Inida"},
                new Country {CountryId = 3, Name = "China"},
            };
        }

    }
}
