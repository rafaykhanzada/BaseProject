using Core.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: api/<RoleController>
        [HttpGet("lookup")]
        public IActionResult GetRolesLookUp()
        {
            return Ok(_roleService.Get());
        }
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = 10, string? Search = null)
        {
            return Ok(_roleService.Get(pageIndex, pageSize, Search));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_roleService.Get(id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleVM model)
        {
            return Ok(await _roleService.CreateOrUpdate(model));
        }

        // PUT api/<RoleController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleVM model)
        {
            return Ok(await _roleService.CreateOrUpdate(model));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _roleService.Delete(id));
        }

    }
}
