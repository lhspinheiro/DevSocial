using DevSocial.Application.UseCases.Posts.Register;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePostJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterPostUseCase useCase, [FromBody] RequestPostJson request)
        {
            var response = await useCase.Execute(request);
            
            return Created(string.Empty, response);
        }
    }
}
