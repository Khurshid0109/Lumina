using Microsoft.AspNetCore.Mvc;
using Lumina.Service.DTOs.Subjects;
using Lumina.Service.Configurations;
using Lumina.Service.Interfaces.Subjects;

namespace Lumina.Api.Controllers.Subjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync([FromQuery] PaginationParams @params)
            =>Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute] long id)
            => Ok(await _service.RetrieveByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] SubjectPostModel model)
            => Ok(await _service.AddAsync(model));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] SubjectPutModel model)
            => Ok(await _service.ModifyAsync(id, model));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            =>Ok(await _service.RemoveAsync(id));
    }
}
