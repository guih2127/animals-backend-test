using Microsoft.AspNetCore.Mvc;
using ShelterBuddy.CodePuzzle.Api.Extensions;
using ShelterBuddy.CodePuzzle.Api.Mapping;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IRepository<Animal, Guid> _repository;

    public AnimalController(IRepository<Animal, Guid> repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public IEnumerable<AnimalModel> GetAll()
    {
        var animals = _repository.GetAll();
        return animals.Select(animal => AnimalMapping.MapEntityToModel(animal)).ToArray();
    }

    [HttpPost]
    public IActionResult Post([FromBody] AnimalModel newAnimal)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        try
        {
            if (newAnimal.Name == null)
                return BadRequest("An animal need to have a name.");

            if (newAnimal.Species == null)
                return BadRequest("An animal need to have a species.");

            if (newAnimal.DateOfBirth == null &&
                newAnimal.AgeMonths == null &&
                newAnimal.AgeYears == null &&
                newAnimal.AgeWeeks == null)
            {
                return BadRequest("Either the date of birth or the age must be informed.");
            }

            if (newAnimal.DateOfBirth > DateTime.Now)
                return BadRequest("The Date of birth can't be in the future.");

            var animalEntity = AnimalMapping.MapModelToEntity(newAnimal);
            _repository.Add(animalEntity);

            var animalModel = AnimalMapping.MapEntityToModel(animalEntity);
            return Ok(animalModel);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred when saving the animal: {ex.Message}");
        }
    }
}