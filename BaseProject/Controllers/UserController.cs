using Core.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;
        public UserController(IUserService userService, IHttpContextAccessor httpContext)
        {
            _userService = userService;
            _httpContext = httpContext;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id) => Ok(await _userService.Get(id));
        [HttpGet("lookup")]
        public IActionResult GetUserLookup(string? type) => Ok(_userService.GetUserLookup(type));
        [HttpGet]
        public IActionResult GetUsers(int pageIndex = 0, int pageSize = 10, string? Search = null) => Ok(_userService.Get(pageIndex, pageSize, Search));
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserVM model, IFormFile? file) => Ok(await _userService.CreateOrUpdate(model, _httpContext, file));

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromForm] UserVM model, IFormFile? file) => Ok(await _userService.CreateOrUpdate(model, _httpContext, file));

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) 
        {
            //string userid = User.Claims.FirstOrDefault().Value;
            return Ok(await _userService.Delete(id, _httpContext, ""));
        } 
    }
}
