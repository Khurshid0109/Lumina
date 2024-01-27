using Microsoft.AspNetCore.Mvc;
using Lumina.Service.DTOs.Teachers;
using Lumina.Service.Configurations;
using Lumina.Service.Interfaces.Teachers;

namespace Lumina.Api.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync([FromQuery] PaginationParams @params)
            =>Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute] long id)
            =>Ok(await _service.RetrieveByIdAsync(id));

        [HttpGet("email")]
        public async Task<IActionResult> SelectByEmailAsync(string email)
            =>Ok(await _service.RetrieveByEmailAsync(email));

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] TeacherPostModel model)
            => Ok(await _service.AddAsync(model));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] TeacherPutModel model)
            => Ok(await _service.ModifyAsync(id, model));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await _service.RemoveAsync(id));
    }
}
