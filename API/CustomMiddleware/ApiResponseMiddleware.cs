using Domain.BaseResponse;
using Newtonsoft.Json;
using System.Text;

namespace API.CustomMiddleware;

public class ApiResponseMiddleware
{
    private readonly RequestDelegate _next;

    public ApiResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Capture the response stream
        var originalBodyStream = context.Response.Body;

        try
        {
            // Replace the response stream with a memory stream
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                // Continue processing the request
                await _next(context);
                string responseContent = "\n---Welcome to my web site!---";
                responseContent = await FormatResponseCode200(context);
                // Write the formatted response to the original response stream
                var bytes = Encoding.UTF8.GetBytes(responseContent);
                await responseBody.WriteAsync(bytes, 0, bytes.Length);

                //Copy the memory stream back to the original response stream
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception exception)
        {
            using (var responseBody = new MemoryStream())
            {

                // Handle exceptions here

                // Create an ResponseModel with error details
                var apiResponse = new ResponseModel<object>
                {
                    Success = false,
                    ErrorMessage = "False",
                    StatusCode = context.Response.StatusCode,
                };

                // Serialize the ResponseModel to JSON
                var formattedResponse = JsonConvert.SerializeObject(apiResponse);

                // Write the formatted response to the original response stream
                var bytes = Encoding.UTF8.GetBytes(formattedResponse);
                await originalBodyStream.WriteAsync(bytes, 0, bytes.Length);
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private async Task<string> FormatResponseCode200(HttpContext context)
    {
        // Read the original response content
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseContent = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        // Parse the original response content or create your custom response format
        var responseData = JsonConvert.DeserializeObject(responseContent);

        // Determine if the status code is an error
        bool isError = context.Response.StatusCode >= 400;
        string errorMessage = null!;

        if (isError)
        {
            switch (context.Response.StatusCode)
            {
                case 400:
                    errorMessage = "Bad Request - The server could not understand the request due to invalid syntax.";
                    break;
                case 401:
                    errorMessage = "Unauthorized - The client must authenticate itself to get the requested response.";
                    break;
                case 403:
                    errorMessage = "Forbidden - The client does not have access rights to the content.";
                    break;
                case 404:
                    errorMessage = "Not Found - The server can not find the requested resource.";
                    break;
                case 500:
                    errorMessage = "Internal Server Error - The server has encountered a situation it doesn't know how to handle.";
                    break;
                case 502:
                    errorMessage = "Bad Gateway - The server, while acting as a gateway or proxy, received an invalid response from the upstream server.";
                    break;
                case 503:
                    errorMessage = "Service Unavailable - The server is not ready to handle the request.";
                    break;
                case 504:
                    errorMessage = "Gateway Timeout - The server is acting as a gateway and cannot get a response in time.";
                    break;
                default:
                    errorMessage = "An error occurred.";
                    break;
            }
        }
        // Create your ApiResponse<T> object
        var apiResponse = new ResponseModel<object>
        {
            Success = !isError,
            ErrorMessage = isError ? errorMessage : null,
            Data = !isError ? responseData : null,
            StatusCode = context.Response.StatusCode,
        };
        // Serialize the ApiResponse<T> object back to JSON
        var formattedResponse = JsonConvert.SerializeObject(apiResponse);

        return formattedResponse;
    }
}
