﻿using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<Person>>
{
    private readonly IDataAccess _data;

    public GetPersonListHandler(IDataAccess data)
    {
        _data = data;
    }
    
    public Task<List<Person>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.GetPeople());
    }
}