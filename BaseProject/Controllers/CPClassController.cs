using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;


namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPClassController : ControllerBase
    {
        private readonly ICPClassService _cpclassService;
        private readonly ICPClassRepository _cpclassRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CPClassController(ICPClassService cpclassService, IHttpContextAccessor httpContextAccessor, ICPClassRepository cpclassRepository, IMapper mapper)
        {
            _cpclassService = cpclassService;
            _httpContextAccessor = httpContextAccessor;
            _cpclassRepository = cpclassRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var list = _cpclassRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_mapper.Map<List<CPClassDTO>>(list));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cpclassService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CPClassDTO model)
        {
            var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _cpclassService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
