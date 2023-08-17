using AutoMapper;
using Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Service.IService;
using Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            //var list = _categoryRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_categoryService.Get(pageIndex,pageSize,Search));
        }
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var result = _categoryService.Export(Search);
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
        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_categoryService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO model)
        {
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(await _categoryService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDTO model)
        {
            if (ModelState.IsValid)
                return Ok(await _categoryService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_categoryService.Delete(id));
        }
    }
}
