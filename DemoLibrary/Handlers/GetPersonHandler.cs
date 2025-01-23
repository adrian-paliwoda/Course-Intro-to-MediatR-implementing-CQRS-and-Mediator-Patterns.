using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonHandler : IRequestHandler<GetPersonQuery,Person>
{
    private readonly IMediator _mediator;

    public GetPersonHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPersonListQuery());
        return result.FirstOrDefault(p => p.Id == request.Id);
    }
}