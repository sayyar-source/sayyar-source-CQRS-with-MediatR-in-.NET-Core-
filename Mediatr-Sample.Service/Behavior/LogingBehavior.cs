using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr_Sample.Service.Behavior
{
    public class LogingBehavior<TReuest, TResponse> : IPipelineBehavior<TReuest, TResponse>
    {
        ILogger<LogingBehavior<TReuest, TResponse>> _logger;
        public LogingBehavior(ILogger<LogingBehavior<TReuest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TReuest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TReuest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
           
        }
    }
}
