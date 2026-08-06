using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Timers;

namespace BuildingBlocks.Logging
{
    public class LoggingBehaviour<TRequest, TResponse>
                (ILogger<LoggingBehaviour<TRequest, TResponse>> logger) :
            IPipelineBehavior<TRequest, TResponse>
                where TRequest : IRequest<TResponse>
                where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle process for {request} and return for {response} with" +
                "                            body {reqbody} at {time}",
                    typeof(TResponse).Name, typeof(TResponse).Name,request, DateTime.UtcNow);
            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            var timetaken = timer.Elapsed;
            if(timetaken.Seconds > 3)
            {
                logger.LogInformation("[PERFORMANCE] took more than 3 seconds");
            }

            logger.LogInformation("[STOP] Handle stopping for {request} with {response} at {time}",
                   typeof(TRequest).Name, typeof(TResponse).Name, DateTime.UtcNow);

            return response;
        }
    }
}
