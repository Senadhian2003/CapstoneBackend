using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add this namespace for ILogger

namespace CoffeeStoreManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAdminAuthService _adminAuthService;
        private readonly ILogger<AuthenticationController> _logger; // Add logger field

        public AuthenticationController(IAuthService authService, IAdminAuthService adminAuthService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _adminAuthService = adminAuthService;
            _logger = logger; // Inject logger
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new ErrorModel(400, string.Join("; ", errors)));
                }

                var result = await _authService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (UnauthorizedUserException uue)
            {
                _logger.LogError(uue, "Unauthorized user exception while logging in"); // Log error
                return Unauthorized(new ErrorModel(401, uue.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while logging in"); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(UserRegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new ErrorModel(400, string.Join("; ", errors)));
                }

                User result = await _authService.Register(registerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering user"); // Log error
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

        [HttpPost("RegisterEmployee")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> EmployeeRegister(UserRegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new ErrorModel(400, string.Join("; ", errors)));
                }

                Employee result = await _adminAuthService.Register(registerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering employee"); // Log error
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

        [HttpPost("EmployeeLogin")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> AdminLogin(UserLoginDTO userLoginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new ErrorModel(400, string.Join("; ", errors)));
                }

                var result = await _adminAuthService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (UnauthorizedUserException uue)
            {
                _logger.LogError(uue, "Unauthorized user exception while logging in as admin"); // Log error
                return Unauthorized(new ErrorModel(401, uue.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while logging in as admin"); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }
    }
}
