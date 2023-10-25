using jcf.billstopay.api.Data.Repositories.IRepositoires;
using jcf.billstopay.api.Models;
using jcf.billstopay.api.Models.ViewModels.User;
using jcf.billstopay.api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;

namespace jcf.billstopay.api.Controllers
{
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    [Route("[controller]/[action]")]
    public class UserController : MyController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        #region CRUD

        [HttpPost, AllowAnonymous]        
        public async Task<IActionResult> Create([Required] User newUser)
        {
            try
            {
                var roleBasic = await _roleRepository.GetByName(ConstantsUtil.BASIC);
                newUser.SetPassword(PasswordUtil.CreateHashMD5(newUser.Password));
                newUser.AddRoles(roleBasic);
                var user = await _userRepository.CreateAsync(newUser);
                if (user is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Error creating record!" });

                return Created(user.Id.ToString(), new { response = user });
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
    }
}
