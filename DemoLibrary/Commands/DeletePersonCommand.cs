using MediatR;

namespace DemoLibrary.Commands;

public record DeletePersonCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeletePersonCommand(int id)
    {
        Id = id;
    }
}