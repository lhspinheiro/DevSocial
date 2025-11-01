using DevSocial.Application.UseCases.Users.Profile;
using DevSocial.Application.UseCases.Users.Register;
using DevSocial.Application.UseCases.Users.Update;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);
            
            return Created(string.Empty, result);
        }
        
        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Profile([FromServices] IGetUserProfileUseCase useCase)
        {
            var response = await useCase.Execute();
            
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] IUpdateUserUseCase useCase,
            [FromBody] RequestUpdateUserJson request)
        {
            await useCase.Execute(request);
            
            return NoContent();
        }
    }
}
