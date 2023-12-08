using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBogus;
using Bogus.DataSets;
using Vote.Monitor.Domain.Entities.ApplicationUserAggregate;
using Vote.Monitor.Domain.Entities.CSOAggregate;

namespace Vote.Monitor.Api.Feature.CSO.UnitTests.Specifications;
public class CSOAggregateFaker : AutoFaker<CSOAggregate>
{
    public CSOAggregateFaker(Guid? id = null, string? name = null)
    {
        RuleFor(fake => fake.Id, id ?? Guid.NewGuid());
        RuleFor(fake => fake.Name, fake => name ?? fake.Name.FullName());
        RuleFor(fake => fake.Status, fake => fake.Random.Int(1, 2) == 1 ? CSOStatus.Activated : CSOStatus.Deactivated);
              

    }
}
