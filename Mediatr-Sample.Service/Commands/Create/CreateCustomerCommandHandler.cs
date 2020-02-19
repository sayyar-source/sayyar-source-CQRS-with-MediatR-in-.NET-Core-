using AutoMapper;
using MediatR;
using Mediatr_Sample.DataLayer;
using Mediatr_Sample.Domain.Models;
using Mediatr_Sample.Models;
using Mediatr_Sample.Service.Commands;
using Mediatr_Sample.Service.Events;
using Mediatr_Sample.Service.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        ShopDBContext _context;
        IMapper _mapper;
        IMediator _mediator;
        public CreateCustomerCommandHandler(ShopDBContext context, IMapper mapper,IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
          
             Customer customer = _mapper.Map<Customer>(request);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
                // Raising Event ...
                await _mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate));

                return _mapper.Map<CustomerDto>(customer);
           
           


        }
    }
}
