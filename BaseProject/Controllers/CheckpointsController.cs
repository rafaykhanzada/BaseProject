using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckpointsController : ControllerBase
    {
        private readonly ICheckpointsService _checkpointService;
        private readonly ICheckpointsRepository _checkpointRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CheckpointsController(ICheckpointsService checkpointService, IHttpContextAccessor httpContextAccessor, ICheckpointsRepository checkpointRepository, IMapper mapper)
        {
            _checkpointService = checkpointService;
            _httpContextAccessor = httpContextAccessor;
            _checkpointRepository = checkpointRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var list = _checkpointRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_mapper.Map<List<CheckpointsDTO>>(list));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_checkpointService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckpointsDTO model)
        {
            var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _checkpointService.CreateOrUpdate(model));
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
            return Ok(_checkpointService.Delete(id));
        }

    }
}
