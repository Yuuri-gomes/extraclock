using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class OvertimeHandler : IRequestHandler<OvertimeQuery, List<Overtime>> {
  private readonly OvertimeRepository _repository;

  public OvertimeHandler(OvertimeRepository repository) {
    _repository = repository;
  }

  public async Task<List<Overtime>> Handle(OvertimeQuery request, CancellationToken cancellationToken) {
    return await _repository.Overtime(request.User);
  }
}