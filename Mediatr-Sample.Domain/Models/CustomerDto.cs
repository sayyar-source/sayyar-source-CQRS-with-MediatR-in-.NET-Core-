using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediatr_Sample.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
