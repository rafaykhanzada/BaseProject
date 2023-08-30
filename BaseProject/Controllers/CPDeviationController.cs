using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;
using Service.Service;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPDeviationController : ControllerBase
    {
        private readonly ICPDeviationService _cpdeviationService;
        private readonly ICPDeviationRepository _cpdeviationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CPDeviationController(ICPDeviationService cpdeviationService, IHttpContextAccessor httpContextAccessor, ICPDeviationRepository cpdeviationRepository, IMapper mapper)
        {
            _cpdeviationService = cpdeviationService;
            _httpContextAccessor = httpContextAccessor;
            _cpdeviationRepository = cpdeviationRepository;
            _mapper = mapper;
        }
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var result = _cpdeviationService.Export(Search);
            if (result.Success == false)
                return BadRequest(result);
            else
            {
                string FileName = ControllerContext.ActionDescriptor.ControllerName + "_" + DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss") + ".xlsx";
                Response.Headers.Add("Content-Disposition", "attachment;filename=" + FileName);
                Response.Headers.Add("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                return File((byte[])result.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 1, int pageSize = int.MaxValue, string? Search = null)
        {
            //var list = _cpdeviationRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_cpdeviationService.Get(pageIndex,pageSize,Search));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cpdeviationService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CPDeviationDTO model)
        {
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _cpdeviationService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CPDeviationDTO model)
        {
            if (ModelState.IsValid)
                return Ok(await _cpdeviationService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_cpdeviationService.Delete(id));
        }

    }
}
