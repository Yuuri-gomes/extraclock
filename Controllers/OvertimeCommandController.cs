using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
    if (command == null)
      return BadRequest("Invalid data for recording overtime.");

    try
    {
      var result = await _mediator.Send(command);
      return CreatedAtAction(nameof(RegisterOvertime), new { id = result }, new { Id = result, Message = "Registered successful overtime !" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { Message = "Internal error processing the request.", Error = ex.Message });
    }
  }
}
