using Lumina.Service.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lumina.Service.Configurations;
using Lumina.Service.Interfaces.Users;

namespace Lumina.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _service.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute] long id)
            =>Ok(await _service.RetrieveByIdAsync(id));

        [HttpGet("email")]
        public async Task<IActionResult> SelectByEmailAsync(string email)
            => Ok(await _service.RetrieveByEmailAsync(email));

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] UserPostModel model)
            => Ok(await _service.AddAsync(model));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id,[FromForm] UserPutModel model)
            =>Ok(await _service.ModifyAsync(id, model));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            =>Ok(await _service.RemoveAsync(id));
    }
}
