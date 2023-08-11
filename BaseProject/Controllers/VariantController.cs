using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantController : ControllerBase
    {
        private readonly IVariantService _variantService;
        private readonly IVariantRepository _variantRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public VariantController(IVariantService variantService, IHttpContextAccessor httpContextAccessor, IVariantRepository variantRepository, IMapper mapper)
        {
            _variantService = variantService;
            _httpContextAccessor = httpContextAccessor;
            _variantRepository = variantRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var list = _variantRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_mapper.Map<List<VariantDTO>>(list));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_variantService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VariantDTO model)
        {
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _variantService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VariantDTO model)
        {
            if (ModelState.IsValid)
                return Ok(await _variantService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_variantService.Delete(id));
        }

    }
}
