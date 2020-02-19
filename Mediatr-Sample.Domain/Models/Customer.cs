using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediatr_Sample.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
