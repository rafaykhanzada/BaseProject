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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor, IProductRepository productRepository, IMapper mapper)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var result = _productService.Export(Search);
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
            //var list = _productRepository.PagedList($"", pageIndex, pageSize).List;
            return Ok(_productService.Get(pageIndex,pageSize,Search));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO model)
        {
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
                return Ok(_productService.CreateOrUpdate(model));
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO model)
        {
            if (ModelState.IsValid)
                return Ok(_productService.CreateOrUpdate(model));
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));
        }

    }
}
