using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service.Events
{
  public  class CustomerCreatedEvent:INotification
    {
        public CustomerCreatedEvent(string firstName, string lastName, DateTime registrationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public DateTime RegistrationDate { get; }
    }
}
