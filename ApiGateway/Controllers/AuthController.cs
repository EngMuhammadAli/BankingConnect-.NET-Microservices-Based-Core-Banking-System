using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.DTO;
using Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ApiGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BaseResponse<LoginResponse>>> Login([FromBody] BaseRequest<LoginRequest> request)
        {
            var response = await CallAuthServiceLogin(request);
            return Ok(response);
        }

        private async Task<BaseResponse<LoginResponse>> CallAuthServiceLogin(BaseRequest<LoginRequest> request)
        {
            var baseUrl = _configuration["ServiceUrls:AuthService"]; // e.g. "http://authservice/api/auth"
            var loginUrl = $"{baseUrl}/login";

            try
            {
                // Send the request object as JSON body
                var httpResponse = await _httpClient.PostAsJsonAsync(loginUrl, request);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return BaseResponse<LoginResponse>.Fail("Auth service call failed.");
                }

                var result = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<LoginResponse>>();
                return result!;
            }
            catch (Exception ex)
            {
                return BaseResponse<LoginResponse>.Fail("Exception |occurred: " + ex.Message);
            }
        }
    }
}
