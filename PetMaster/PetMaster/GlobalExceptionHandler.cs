using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PetMaster.ViewModels;

namespace PetMaster
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message, null);
            context.Result = new BadRequestObjectResult(GetExceptionObject(context));
        }

        private ErrorVm GetExceptionObject(ExceptionContext context)
        {
            var result = new ErrorVm
            {
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            return result;
        }
    }
}
