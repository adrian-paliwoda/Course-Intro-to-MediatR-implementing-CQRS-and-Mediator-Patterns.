using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, Person>
{
    private readonly IDataAccess _data;

    public InsertPersonHandler(IDataAccess _data)
    {
        this._data = _data;
    }

    public Task<Person> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
    }
}