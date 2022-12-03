using ShelterBuddy.CodePuzzle.Api.Responses;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Services
{
    public interface IAnimalService
    {
        AnimalResponse Save(Animal animal);
        IEnumerable<Animal> GetAll();
    }
}
