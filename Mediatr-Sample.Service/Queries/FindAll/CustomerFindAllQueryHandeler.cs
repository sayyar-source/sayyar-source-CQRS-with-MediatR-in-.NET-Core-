using AutoMapper;
using MediatR;
using Mediatr_Sample.DataLayer;
using Mediatr_Sample.Domain.Models;
using Mediatr_Sample.Models;
using Mediatr_Sample.Service.Queries.FindAll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Handelers.FindAll
{
    public class CustomerFindAllQueryHandeler : IRequestHandler<CustomerFindAllQuery, IList<CustomerDto>>
    {
        private readonly ShopDBContext _db;
        private readonly IMapper _mapper;
        public CustomerFindAllQueryHandeler(ShopDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IList<CustomerDto>> Handle(CustomerFindAllQuery request, CancellationToken cancellationToken)
        {
            var model =await _db.Customers.ToListAsync();
            return model.Select(_mapper.Map<Customer, CustomerDto>).ToList();
        }
    }
}
