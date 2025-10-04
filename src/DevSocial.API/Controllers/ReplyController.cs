using DevSocial.Application.UseCases.Reply.Delete;
using DevSocial.Application.UseCases.Reply.Reply;
using DevSocial.Application.UseCases.Reply.Update;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace DevSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType( typeof(ResponseListReplyJson), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Reply([FromServices] IReplyUSeCase uSeCase,[FromBody] RequestToReplyJson request)
        {
            var response = await uSeCase.Execute(request);
            
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute]long id, [FromServices] IUpdateReplyUseCase useCase, [FromBody] RequestToReplyJson request)
        {
           await useCase.Execute(id, request);
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id,  [FromServices] IDeleteReplyUseCase useCase)
        {
            await useCase.Execute(id);
            
            return NoContent();
        }
    }
}
