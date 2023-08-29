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
    public class ZoneController : ControllerBase
    {
        private readonly IZoneService _zoneService;
        private readonly IZoneRepository _zoneRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IAuditLoggerService _auditLoggerService;

        public ZoneController(IZoneService zoneService, IHttpContextAccessor httpContextAccessor, IZoneRepository zoneRepository, IMapper mapper, IAuditLoggerService auditLoggerService)
        {
            _zoneService = zoneService;
            _httpContextAccessor = httpContextAccessor;
            _zoneRepository = zoneRepository;
            _mapper = mapper;
            _auditLoggerService = auditLoggerService;
        }
        [HttpGet("export")]
        public IActionResult Get(string? Search = null)
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = _auditLoggerService.ExtractJWT(jwtToken);
            var result = _zoneService.Export(userId, Search);
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
            //var list = _zoneRepository.PagedList($"", pageIndex, pageSize).List;
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = _auditLoggerService.ExtractJWT(jwtToken);
            return Ok(_zoneService.Get(userId, pageIndex,pageSize,Search));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = _auditLoggerService.ExtractJWT(jwtToken);
            return Ok(_zoneService.Get(userId, id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ZoneDTO model)
        {
            //var user = _httpContextAccessor.HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
            {
                var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var userId = _auditLoggerService.ExtractJWT(jwtToken);
                return Ok(await _zoneService.CreateOrUpdate(userId, model));

            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ZoneDTO model)
        {
            if (ModelState.IsValid)
            {
                var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var userId = _auditLoggerService.ExtractJWT(jwtToken);
                return Ok(await _zoneService.CreateOrUpdate(userId, model));

            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = _auditLoggerService.ExtractJWT(jwtToken);
            return Ok(_zoneService.Delete(userId, id));
        }


    }
}
