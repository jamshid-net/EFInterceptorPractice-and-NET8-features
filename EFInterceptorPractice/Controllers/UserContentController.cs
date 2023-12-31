using Application.UseCases.UserContentService.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFInterceptorPractice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class UserContentController : BaseController
{

    
    [HttpPost] 
    public async Task<ActionResult<bool>> CreateUserContent(CreateUserContentCommand command)
        => await _mediator.Send(command);
    
}
