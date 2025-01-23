using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Queries;

public record GetPersonQuery(int Id) : IRequest<Person>
{
    public int Id { get; set; }
}