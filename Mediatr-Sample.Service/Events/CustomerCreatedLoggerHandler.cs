using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Events
{
    public class CustomerCreatedLoggerHandler : INotificationHandler<CustomerCreatedEvent>
    {
        ILogger<CustomerCreatedLoggerHandler> _logger;
        public CustomerCreatedLoggerHandler(ILogger<CustomerCreatedLoggerHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at:{notification.RegistrationDate}:{notification.FirstName}:{notification.LastName}");
            return Task.CompletedTask;
        }
    }
}
