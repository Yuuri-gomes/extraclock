using MediatR;
using System;

public class RegisterOvertimeCommand : IRequest<Guid> {
  public required string User { get; set; }
  public required String InitialTime { get; set; }
  public required String FinishTime { get; set; }
  public string? Description { get; set; }
}