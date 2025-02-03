using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v1/overtime")]
public class OvertimeCommandController : ControllerBase
{
  private readonly IMediator _mediator;

  public OvertimeCommandController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("register")]
  public async Task<IActionResult> RegisterOvertime([FromBody] RegisterOvertimeCommand command)
  {
    var result = await _mediator.Send(command);
    return Ok(new { Id = result, Mensagem = "Hora extra registrada!" });
  }
}

