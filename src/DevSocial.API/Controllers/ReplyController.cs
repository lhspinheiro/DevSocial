using DevSocial.Application.UseCases.Reply.Reply;
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
    }
}
