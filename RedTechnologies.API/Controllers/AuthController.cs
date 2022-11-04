using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RedTechnologies.App;
using RedTechnologies.App.Application;
using RedTechnologies.App.Command;
using RedTechnologies.Repository.Repository;
using System;
using System.Threading.Tasks;

namespace RedTechnologies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthAppService _authAppService;
        public AuthController(IOptions<AppSettings> appSettings, IUserRepository userRepository, IMapper mapper)
        {
            _authAppService = new AuthAppService(appSettings.Value, userRepository, mapper);
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserCommand userCommand)
        {
            try
            {
                bool userValid = await _authAppService.ValidateUserAsync(userCommand);
                if (userValid)
                {
                    string tokenString = _authAppService.CreateTokenJWT();
                    return Ok(new ResultHttp { Code = 200, Msg = "success", Data = new { token = tokenString } });
                }
                else
                    return Ok(new ResultHttp { Code = 401, Msg = "error", Data = "Unauthorized access!" });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }
        }
    }
}

