using AutoMapper;
using MediatR;
using Mediatr_Sample.DataLayer;
using Mediatr_Sample.Domain.Models;
using Mediatr_Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Queries.FindById
{
    public class FindCustomerByIdQueryHandeler : IRequestHandler<FindCustomerByIdQuery, CustomerDto>
    {
        private readonly ShopDBContext _db;
        private readonly IMapper _mapper;
        public FindCustomerByIdQueryHandeler(ShopDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.Customers.FindAsync(request.Id);

            // For testing PerformanceBehavior
            await Task.Delay(5000, cancellationToken);
            return _mapper.Map<Customer, CustomerDto>(model);
        }
    }
}
