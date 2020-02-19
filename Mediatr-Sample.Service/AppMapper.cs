using AutoMapper;
using Mediatr_Sample.Domain.Models;
using Mediatr_Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service
{
   public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
