namespace Net6ODataPoc.WebApi.Filters
{
    using System.Net.Mime;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Net6ODataPoc.Application.Common;
    using Net6ODataPoc.Application.Common.Constants;

    internal sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilterAttribute> logger;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            this.HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            this.logger.LogError(context.Exception, context.Exception.Message);

            var exceptionHandler = context.Exception switch
            {
                _ => new Action<ExceptionContext>(this.HandleUnknownException),
            };

            exceptionHandler.Invoke(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var response = new BaseResponse<object>
            {
                Code = ErrorCodes.UNKNOWN_ERROR,
                Error = ErrorCodes.UNKNOWN_ERROR_MESSAGE,
            };

            context.Result = new ObjectResult(response)
            {
                ContentTypes = new MediaTypeCollection
                {
                    MediaTypeNames.Application.Json,
                },
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
        }
    }
}
