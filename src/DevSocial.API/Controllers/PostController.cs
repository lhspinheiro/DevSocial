using DevSocial.Application.UseCases.Posts.Delete;
using DevSocial.Application.UseCases.Posts.GetAll;
using DevSocial.Application.UseCases.Posts.GetById;
using DevSocial.Application.UseCases.Posts.GetMyPosts;
using DevSocial.Application.UseCases.Posts.Register;
using DevSocial.Application.UseCases.Posts.Update;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePostJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterPostUseCase useCase,
            [FromBody] RequestPostJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseLIstPostJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMyPosts([FromServices] IGetAllMyPostsUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("AllPosts")]
        [ProducesResponseType(typeof(ResponseLIstPostJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPosts([FromServices] IGetAllPostsUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }


        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseLIstPostJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long id, [FromServices] IGetByIdPostUseCase useCase)
        {
            var response = await useCase.Execute(id);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePost([FromRoute] long id, [FromServices] IUpdatePostUseCase useCase,
            [FromBody] RequestPostJson request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] IDeletePostUseCase useCase)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}