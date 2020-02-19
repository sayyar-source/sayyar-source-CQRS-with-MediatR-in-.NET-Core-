using FluentValidation;
using Mediatr_Sample.Service.Commands;
using Mediatr_Sample.Service.Commands.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.Service.Validation
{
   public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Costumer should  have a name");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Costumer should  have a lastname");

        }
    }
}
