using jcf.billstopay.api.Data.Repositories.IRepositoires;
using jcf.billstopay.api.Models;
using jcf.billstopay.api.Models.ViewModels.User;
using jcf.billstopay.api.Services.IServices;
using jcf.billstopay.api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace jcf.billstopay.api.Controllers
{
    [ApiController]
    [Authorize(Roles = "ADMIN,BASIC")]
    [Route("[controller]/[action]")]
    public class UserController : MyController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, ITokenService tokenService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        #region CRUD

        [HttpPost, AllowAnonymous]        
        public async Task<IActionResult> Create([Required] User newUser)
        {
            try
            {                
                newUser.SetPassword(PasswordUtil.CreateHashMD5(newUser.Password));
                               
                var user = await _userRepository.CreateAsync(newUser);
                if (user is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Error creating record!" });

                return Created(user.Id.ToString(), new { response = new { user.Name, user.UserName, user.Email, user.CreateAt, user.FirstName } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                var entity = await _userRepository.GetAsync(id);
                if (entity is null) return NoContent();

                entity.SetPassword(string.Empty);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] UserViewModel updateUser)
        {
            try
            {
                if (id != updateUser.Id) return NoContent();

                var entity = await _userRepository.GetAsync(id);
                if (entity is null) return NoContent();

                entity.Update(updateUser.Name, updateUser.Email, updateUser.UserName);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        #endregion

        #region Authenticate

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel auth)
        {
            try
            {
                var user = await _userRepository.AuthenticateAsync(auth.UserName, PasswordUtil.CreateHashMD5(auth.Password));
                if (user == null) return BadRequest(new { error = true, message = "Invalid username or password!" });

                return Ok(new
                {
                    userName = user.UserName,
                    name = user.Name,
                    token = _tokenService.GenerateToken(user),
                    user.FirstName
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        #endregion
    }
}
