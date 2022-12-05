using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ShelterBuddy.CodePuzzle.Api.Controllers;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;
using ShelterBuddy.CodePuzzle.Utils;
using Shouldly;
using Xunit;

namespace ShelterBuddy.CodePuzzle.Api.Tests.Controllers;

public class AnimalControllerTests
{
    [Fact]
    public void Get_WithEmptyRepository_IsEmpty()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var controller = new AnimalController(repository);

        controller.GetAll().ShouldBeEmpty();
    }

    [Fact]
    public void Get_WithData_ReturnsExpectedResults()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var data = new Animal[]
        {
            new()
            {
                Id = new Guid("3bb2a7e5-979a-48df-9cc3-1bc1475917e3"),
                Name = "Fido",
                Color = "White",
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
        repository.GetAll().Returns(data);
        var controller = new AnimalController(repository);

        var results = controller.GetAll();

        results.ShouldNotBeEmpty();
        results.Count().ShouldBe(2);
        var firstResult = results.Single(r => r.Id == "3bb2a7e5-979a-48df-9cc3-1bc1475917e3");
        var (years, months, weeks)
            = DateTimeUtils.CompareDates(firstResult.DateOfBirth.GetValueOrDefault(), DateTime.Now);
        firstResult.Name.ShouldBe("Fido");
        firstResult.Color.ShouldBe("White");
        firstResult.Species.ShouldBe("Dog");
        firstResult.DateFound.ShouldBe(new DateTime(2019, 6, 3));
        firstResult.DateLost.ShouldBe(new DateTime(2019, 5, 23));
        firstResult.MicrochipNumber.ShouldBe("12345");
        firstResult.DateInShelter.ShouldBe(new DateTime(2019, 6, 4));
        firstResult.DateOfBirth.ShouldBe(new DateTime(2017, 3, 13));
        firstResult.AgeText.ShouldBe($"{years} years {months} months {weeks} weeks");
        firstResult.AgeYears.ShouldBeNull();
        firstResult.AgeMonths.ShouldBeNull();
        firstResult.AgeWeeks.ShouldBeNull();

        var secondResult = results.Single(r => r.Id == "31d36744-2085-43f8-b443-59a93379ee01");
        secondResult.Name.ShouldBe("Spot");
        secondResult.Color.ShouldBeNull();
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

    [Fact]
    public void Post_WithEmptySpecies_DontInsert()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var data = new SaveAnimalModel
        {
            Name = "Fido",
            Color = "White",
            DateFound = new DateTime(2019, 6, 3),
            DateLost = new DateTime(2019, 5, 23),
            MicrochipNumber = "12345",
            DateInShelter = new DateTime(2019, 6, 4),
            DateOfBirth = new DateTime(2017, 3, 13),
        };

        var controller = new AnimalController(repository);
        var result = controller.Post(data);

        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void Post_WithEmptyName_DontInsert()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var data = new SaveAnimalModel
        {
            Color = "White",
            Species = "Dog",
            DateFound = new DateTime(2019, 6, 3),
            DateLost = new DateTime(2019, 5, 23),
            MicrochipNumber = "12345",
            DateInShelter = new DateTime(2019, 6, 4),
            DateOfBirth = new DateTime(2017, 3, 13),
        };

        var controller = new AnimalController(repository);
        var result = controller.Post(data);

        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void Post_WithFutureDateOfBirth_DontInsert()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var data = new SaveAnimalModel
        {
            Name = "Fido",
            Color = "White",
            Species = "Dog",
            DateFound = new DateTime(2019, 6, 3),
            DateLost = new DateTime(2019, 5, 23),
            MicrochipNumber = "12345",
            DateInShelter = new DateTime(2019, 6, 4),
            DateOfBirth = new DateTime(2025, 3, 13),
        };

        var controller = new AnimalController(repository);
        var result = controller.Post(data);

        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void Post_WithCorrectData_Inserts()
    {
        var repository = Substitute.For<IRepository<Animal, Guid>>();
        var data = new SaveAnimalModel
        {
            Name = "Fido",
            Color = "White",
            Species = "Dog",
            DateFound = new DateTime(2019, 6, 3),
            DateLost = new DateTime(2019, 5, 23),
            MicrochipNumber = "12345",
            DateInShelter = new DateTime(2019, 6, 4),
            DateOfBirth = new DateTime(2017, 3, 13),
        };

        var controller = new AnimalController(repository);
        var result = controller.Post(data);

        var objectResponse = result.ShouldBeOfType<OkObjectResult>();
        var insertedAnimal = objectResponse.Value.ShouldBeOfType<AnimalModel>();

        insertedAnimal.Name.ShouldBe("Fido");
        insertedAnimal.Color.ShouldBe("White");
        insertedAnimal.Species.ShouldBe("Dog");
        insertedAnimal.DateFound.ShouldBe(new DateTime(2019, 6, 3));
        insertedAnimal.DateLost.ShouldBe(new DateTime(2019, 5, 23));
        insertedAnimal.MicrochipNumber.ShouldBe("12345");
        insertedAnimal.DateInShelter.ShouldBe(new DateTime(2019, 6, 4));
        insertedAnimal.DateOfBirth.ShouldBe(new DateTime(2017, 3, 13));
    }
}
