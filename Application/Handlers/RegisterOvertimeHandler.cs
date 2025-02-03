using MediatR;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

public class RegisterOvertimeHandler: IRequestHandler<RegisterOvertimeCommand, Guid> {
  private readonly OvertimeRepository _repository;
  private readonly IMediator _mediator;

  public RegisterOvertimeHandler(OvertimeRepository repository, IMediator mediator) {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Guid> Handle(RegisterOvertimeCommand request, CancellationToken cancellationToken) {
    string datePattern = "yyyy-MM-dd HH:mm:ss";
    string initalTimeformattedDate = request.InitialTime;
    string finishTimeFormattedDate = request.FinishTime;

    var initialTimeUtc = DateTime.ParseExact(initalTimeformattedDate, datePattern, CultureInfo.InvariantCulture).ToUniversalTime();
    var finishTimeUtc = DateTime.ParseExact(finishTimeFormattedDate, datePattern, CultureInfo.InvariantCulture).ToUniversalTime();
    
    var overtime = new Overtime
    {
      Id = Guid.NewGuid(),
      User = request.User,
      InitialTime = initialTimeUtc,
      FinishTime = finishTimeUtc,
      Description = request.Description?.Trim() ?? "",
      Date = DateTime.UtcNow
    };


    await _repository.RegisterOvertime(overtime);
    await _mediator.Publish(new RegisteredOvertimeEvent(overtime.Id, overtime.User, overtime.InitialTime, overtime.FinishTime, overtime.Description));

    return overtime.Id;
  }
}