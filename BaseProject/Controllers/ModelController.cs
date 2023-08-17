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
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IModelRepository _modelRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ModelController(IModelService modelService, IHttpContextAccessor httpContextAccessor, IModelRepository modelRepository, IMapper mapper)
        {
            _modelService = modelService;
            _httpContextAccessor = httpContextAccessor;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var result = _modelService.Export(Search);
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
            //var list = _modelRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_modelService.Get(pageIndex,pageSize,Search));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_modelService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelDTO model)
        {
            var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _modelService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ModelDTO model)
        {
            if (ModelState.IsValid)
                return Ok(await _modelService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_modelService.Delete(id));
        }

    }
}
