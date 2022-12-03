using AutoMapper;
using NSubstitute;
using ShelterBuddy.CodePuzzle.Api.Controllers;
using ShelterBuddy.CodePuzzle.Api.Services;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;
using Shouldly;
using Utils;
using Xunit;

namespace ShelterBuddy.CodePuzzle.Api.Tests.Controllers;

public class AnimalControllerTests
{
    [Fact]
    public void Get_WithEmptyRepository_IsEmpty()
    {
        var service = Substitute.For<IAnimalService>();
        var mapper = Substitute.For<IMapper>();
        var controller = new AnimalController(service, mapper);

        controller.GetAll().ShouldBeEmpty();
    }

    [Fact]
    public void Get_WithData_ReturnsExpectedResults()
    {
        var service = Substitute.For<IAnimalService>();
        var mapper = Substitute.For<IMapper>();
        var data = new Animal[]
        {
            new()
            {
                Id = new Guid("3bb2a7e5-979a-48df-9cc3-1bc1475917e3"),
                Name = "Fido",
                Colour = "White",
                Species = "Dog",
                DateFound = new DateTime(2019, 6, 3),
                DateLost = new DateTime(2019, 5, 23),
                MicrochipNumber = "12345",
                DateInShelter = new DateTime(2019, 6, 4),
                DateOfBirth = new DateTime(2017, 3, 13),
            },
            new()
            {
                Id = new Guid("31d36744-2085-43f8-b443-59a93379ee01"),
                Name = "Spot",
                Species = "Dog",
                AgeYears = 1,
                AgeMonths = 2,
                AgeWeeks = 3,
            }
        }.AsQueryable();
        service.GetAll().Returns(data);
        var controller = new AnimalController(service, mapper);

        var results = controller.GetAll();

        results.ShouldNotBeEmpty();
        results.Count().ShouldBe(2);
        var firstResult = results.Single(r => r.Id == "3bb2a7e5-979a-48df-9cc3-1bc147e5917e3");
        var (years, months, weeks) 
            = DateTimeUtils.DateDiff(firstResult.DateOfBirth.GetValueOrDefault(), DateTime.Now);
        firstResult.Name.ShouldBe("Fido");
        firstResult.Colour.ShouldBe("White");
        firstResult.Species.ShouldBe("Dog");
        firstResult.DateFound.ShouldBe(new DateTime(2019, 6, 3));
        firstResult.DateLost.ShouldBe(new DateTime(2019, 5, 23));
        firstResult.MicrochipNumber.ShouldBe("12345");
        firstResult.DateInShelter.ShouldBe(new DateTime(2019, 6, 4));
        firstResult.DateOfBirth.ShouldBe(new DateTime(2017,3, 13));
        firstResult.AgeText.ShouldBe($"{years} years {months} months {weeks} weeks");
        firstResult.AgeYears.ShouldBeNull();
        firstResult.AgeMonths.ShouldBeNull();
        firstResult.AgeWeeks.ShouldBeNull();

        var secondResult = results.Single(r => r.Id == "31d36744-2085-43f8-b443-59a93379ee01");
        secondResult.Name.ShouldBe("Spot");
        secondResult.Colour.ShouldBeNull();
        secondResult.Species.ShouldBe("Dog");
        secondResult.DateFound.ShouldBeNull();
        secondResult.DateLost.ShouldBeNull();
        secondResult.MicrochipNumber.ShouldBeNull();
        secondResult.DateInShelter.ShouldBeNull();
        secondResult.DateOfBirth.ShouldBeNull();
        secondResult.AgeText.ShouldBe("1 years 2 months 3 weeks");
        secondResult.AgeYears.ShouldBe(1);
        secondResult.AgeMonths.ShouldBe(2);
        secondResult.AgeWeeks.ShouldBe(3);
    }
}
