using MediatR;
using Mediatr_Sample.Models;
using Mediatr_Sample.Service.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Commands.Create
{
    public class CreateCustomerValidationBehavior<TRequset, TResponse> : IPipelineBehavior<CreateCustomerCommand, CustomerDto>
    {
        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CustomerDto> next)
        {
            var validator = new CreateCustomerCommandValidator();
            var check = validator.Validate(request);
            if (check.IsValid)
            {
                var response = await next();
                return response;
            }
            else
            {
                throw new Exception("costumer is not valid.");
            }
        }
    }
}
