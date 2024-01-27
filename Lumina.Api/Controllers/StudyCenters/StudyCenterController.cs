using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lumina.Service.Configurations;
using Lumina.Service.DTOs.StudyCenters;
using Lumina.Service.Interfaces.StudyCenters;

namespace Lumina.Api.Controllers.StudyCenters
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyCenterController : ControllerBase
    {
        private readonly IStudyCenterService _service;

        public StudyCenterController(IStudyCenterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync([FromQuery] PaginationParams @params)
            =>Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute] long id)
            =>Ok(await _service.RetrieveByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] StudyCenterPostModel model)
            =>Ok(await _service.AddAsync(model));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] StudyCenterPutModel model)
            => Ok(await _service.ModifyAsync(id, model));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] long id)
            =>Ok(await _service.RemoveAsync(id));
    }
}
