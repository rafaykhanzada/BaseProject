using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService permissionService, IHttpContextAccessor httpContextAccessor, IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionService = permissionService;
            _httpContextAccessor = httpContextAccessor;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _permissionService.GetMenuoutWithAction());
        }
        // GET api/<PermissionController>/5
        [HttpGet("{roleId}")]
        public async Task<IActionResult> Get(string roleId)
        {
            return Ok(await _permissionService.GetMenuWithAction(roleId));
        }
        // POST api/<PermissionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolePermissionVM model)
        {
            return Ok(await _permissionService.CreatePermissionWithRole(model));
        }

    }
}
