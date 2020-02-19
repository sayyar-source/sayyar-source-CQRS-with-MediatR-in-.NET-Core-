using MediatR;
using Mediatr_Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service.Queries.FindById
{
   public class FindCustomerByIdQuery:IRequest<CustomerDto>
    {
        public int Id { get; set; }

    }
}
