using MediatR;
using System.Collections.Generic;

public class OvertimeQuery : IRequest<List<Overtime>> {
  public string User { get; }
  public OvertimeQuery(string user) {
    User = user;
  }
}