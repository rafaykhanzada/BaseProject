using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultGroupController : ControllerBase
    {
        private readonly IFaultGroupService _faultgroupService;
        private readonly IFaultGroupRepository _falultgroupRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public FaultGroupController(IFaultGroupService faultgroupService, IHttpContextAccessor httpContextAccessor, IFaultGroupRepository falultgroupRepository, IMapper mapper)
        {
            _faultgroupService = faultgroupService;
            _httpContextAccessor = httpContextAccessor;
            _falultgroupRepository = falultgroupRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var list = _falultgroupRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_mapper.Map<List<FaultGroupDTO>>(list));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_faultgroupService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FaultGroupDTO model)
        {
            var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _faultgroupService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_faultgroupService.Delete(id));
        }

    }
}
