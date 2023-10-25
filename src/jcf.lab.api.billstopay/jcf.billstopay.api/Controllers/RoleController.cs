using jcf.billstopay.api.Data.Repositories.IRepositoires;
using jcf.billstopay.api.Models;
using jcf.billstopay.api.Models.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace jcf.billstopay.api.Controllers
{
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    [Route("[controller]/[action]")]
    public class RoleController : MyController
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleRepository _roleRepository;

        public RoleController(ILogger<RoleController> logger, IRoleRepository roleRepository)
        {
            _logger = logger;
            _roleRepository = roleRepository;
        }

        #region Crud

        [HttpPost]
        public async Task<IActionResult> Create([Required] Role newRole)
        {
            try
            {
                var role = await _roleRepository.CreateAsync(newRole);
                if (role is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Error creating record!" });
                
                return Created(role.Id.ToString(), new { response = role });
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
                var role = await _roleRepository.GetAsync(id);
                if (role is null) return NoContent();
                              
                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var role = await _roleRepository.GetAll();
                if (role is null) return NoContent();

                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] RoleViewModel updateRole)
        {
            try
            {
                if (id != updateRole.Id) return NoContent();

                var role = await _roleRepository.GetAsync(id);
                if (role is null) return NoContent();

                role.Update(updateRole.RoleName);
                return Ok(role);
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
