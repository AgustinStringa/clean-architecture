namespace API.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (KeyNotFoundException ex)
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
				await context.Response.WriteAsJsonAsync(new { Error = ex.Message });
			}
			catch (Exception)
			{
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsJsonAsync(new { Error = "An unexpected error occurred." });
			}
		}
	}

}
