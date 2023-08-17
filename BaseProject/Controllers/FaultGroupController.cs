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
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var result = _faultgroupService.Export(Search);
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
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            //var list = _falultgroupRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_faultgroupService.Get(pageIndex,pageSize,Search));
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
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _faultgroupService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FaultGroupDTO model)
        {
            if (ModelState.IsValid)
                return Ok(await _faultgroupService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_faultgroupService.Delete(id));
        }

    }
}
