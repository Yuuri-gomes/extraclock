using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v1/overtime")]
public class OvertimeQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public OvertimeQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("list")]
    public async Task<IActionResult> SearchOvertime([FromQuery] string user)
    {
        var result = await _mediator.Send(new OvertimeQuery(user));
        return Ok(result);
    }
}
