using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShelterBuddy.CodePuzzle.Api.Extensions;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Api.Services;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;
    private readonly IMapper _mapper;

    public AnimalController(IAnimalService animalService, IMapper mapper)
    {
        _animalService = animalService;
        _mapper = mapper;
    }


    [HttpGet]
    public IEnumerable<AnimalModel> GetAll()
    {
        var animals = _animalService.GetAll();
        var models = _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalModel>>(animals);

        return models;
    }

    [HttpPost]
    public IActionResult Post([FromBody] AnimalModel newAnimal)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var animal = _mapper.Map<AnimalModel, Animal>(newAnimal);
        var result = _animalService.Save(animal);

        if (!result.Success)
            return BadRequest(result.Message);

        var animalModel = _mapper.Map<Animal, AnimalModel>(result.Animal);
        return Ok(animalModel);
    }
}