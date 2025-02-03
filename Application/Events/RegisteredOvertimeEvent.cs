using MediatR;
using System;

public class RegisteredOvertimeEvent : INotification
{
  public Guid Id { get; }
  public string User { get; }
  public DateTime InitialTime { get; }
  public DateTime FinishTime { get; }
  public string Description { get; }

  public RegisteredOvertimeEvent(Guid id, string user, DateTime initialTime, DateTime finishTime, string description) {
    Id = id;
    User = user;
    InitialTime = initialTime;
    FinishTime = finishTime;
    Description = description;
  }
}