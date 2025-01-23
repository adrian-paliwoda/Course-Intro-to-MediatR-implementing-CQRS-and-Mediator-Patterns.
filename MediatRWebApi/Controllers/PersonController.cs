using System.Collections;
using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Person>> GetPeople()
    {
        return await _mediator.Send(new GetPersonListQuery());
    }

    [HttpGet("{id}")]
    public async Task<Person> GetPerson(int id)
    {
        return await _mediator.Send(new GetPersonQuery(id));
    }

    [HttpPost]
    public async Task<Person> InsertPerson([FromBody] InsertPersonCommand person)
    {
        return await _mediator.Send(new InsertPersonCommand(person.FirstName, person.LastName));
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeletePerson(int id)
    {
        return await _mediator.Send(new DeletePersonCommand(id));
    }
}