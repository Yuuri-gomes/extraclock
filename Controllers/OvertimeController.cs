using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v1/overtime")]
public class OvertimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public OvertimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registrar([FromBody] RegisterOvertimeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { Id = result, Mensagem = "Hora extra registrada!" });
    }

    [HttpGet("list")]
    public async Task<IActionResult> SearchOvertime([FromQuery] string user)
    {
        var result = await _mediator.Send(new OvertimeQuery(user));
        return Ok(result);
    }
}
