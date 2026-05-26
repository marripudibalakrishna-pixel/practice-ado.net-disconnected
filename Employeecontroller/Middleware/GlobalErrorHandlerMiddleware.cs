namespace Employeecontroller.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {

        public readonly RequestDelegate _next;
        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //context.Response.StatusCode = 500;
                //context.Response.ContentType = "application/json";
                //var errorResponse = new { message = "An unexpected error occurred.", details = ex.Message };
                //await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
