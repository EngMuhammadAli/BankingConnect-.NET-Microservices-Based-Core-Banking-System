using System.ComponentModel.DataAnnotations;
using AuthService.Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Models;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login()
        {
            await Task.Delay(100);

            var mockData = new LoginResponse
            {
                UserId = 1,
                Username = "Ali +923331344986",
                Token = "wkfejwjgklqewgjqsklvncxklvjiodgkrengmqwjkfhvcjischjklsnvjksnfm"
            };

            var response = BaseResponse<LoginResponse>.SuccessResponse(mockData, "Login successful");
            return Ok(response);
        }
    }

    
}
