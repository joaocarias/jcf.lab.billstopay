using jcf.billstopay.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required] Role role)
        {
            try
            {

                return Created(role.Id.ToString(), role);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

    }
}
