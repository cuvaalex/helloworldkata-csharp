﻿using Microsoft.EntityFrameworkCore;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Persistence;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure;

public class HelloWorldRepository : IHelloWorldRepository
{
    private readonly DatabaseContext _dbContext;

    public HelloWorldRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(HelloWorldEntity helloWorldEntity)
    {
        var record = new HelloWorldRecord.Builder()
            .Id(helloWorldEntity.helloWorldId.helloWorldId)
            .Name(helloWorldEntity.name.Name).Build();
        _dbContext.HelloWorlds.Add(record);
        _dbContext.SaveChanges();
    }

    public async Task<HelloWorldEntity> GetAsync(HelloWorldId helloworldId)
    {
        var record = await _dbContext.HelloWorlds
            .Where(e => e.Id == helloworldId.helloWorldId)
            .SingleOrDefaultAsync();
        return new HelloWorldEntity(HelloWorldId.From(record.Id)
            , HelloWorldName.From(record.Name));
    }
}