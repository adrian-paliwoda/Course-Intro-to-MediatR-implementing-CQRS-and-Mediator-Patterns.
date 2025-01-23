using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using MediatR;

namespace DemoLibrary.Handlers;

public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IDataAccess _data;

    public DeletePersonHandler(IDataAccess data)
    {
        _data = data;
    }
    
    public Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.DeletePerson(request.Id));
    }
    
}