using MediatR;
using Mediatr_Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service.Queries.FindAll
{
  public  class CustomerFindAllQuery:IRequest<IList<CustomerDto>>
    {
    }
}
