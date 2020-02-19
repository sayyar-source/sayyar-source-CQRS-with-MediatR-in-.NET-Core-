using AutoMapper;
using Mediatr_Sample.Domain.Models;
using Mediatr_Sample.Models;
using Mediatr_Sample.Service.Commands;
using Mediatr_Sample.Service.Commands.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service
{
  public  class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(c => c.RegistrationDate, opt => opt.MapFrom(p => DateTime.Now));

            CreateMap<Customer, CustomerDto>()
           .ForMember(cd => cd.RegistrationDate, opt =>
               opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));
        }
    }
}
