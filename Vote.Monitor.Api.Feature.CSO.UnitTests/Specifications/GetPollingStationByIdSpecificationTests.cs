using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Vote.Monitor.Api.Feature.CSO.Specifications;

namespace Vote.Monitor.Api.Feature.CSO.UnitTests.Specifications;
public class GetPollingStationByIdSpecificationTests
{
    [Fact]
    public void GetPollingStationByIdSpecification_AppliesCorrectFilters()
    {
        //Arrange
        var cso = new CSOAggregateFaker(Guid.NewGuid()).Generate();

        var testCollection = new CSOAggregateFaker()
            .Generate(500)
            .ToList();

        var spec = new GetCSOByNameSpecification(cso.Name.ToString());

        //Act
        var result = spec.Evaluate(testCollection).ToList();

        //Assert
        result.Should().HaveCountGreaterThanOrEqualTo(1);
        result.Should().Contain(cso);
    }
}
