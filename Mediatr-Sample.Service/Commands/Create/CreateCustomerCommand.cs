using MediatR;
using Mediatr_Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service.Commands.Create
{
  public  class CreateCustomerCommand:IRequest<CustomerDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        //public CreateCustomerCommand(string firstName, string lastName)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;

        //}
    }
}
