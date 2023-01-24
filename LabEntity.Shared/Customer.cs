using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEntity.Shared
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name max length is 50.")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Last name max length is 50.")]
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; } = default!;
    }
}
