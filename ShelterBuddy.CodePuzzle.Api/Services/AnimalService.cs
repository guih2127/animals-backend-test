using ShelterBuddy.CodePuzzle.Api.Responses;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal, Guid> repository;

        public AnimalService(IRepository<Animal, Guid> animalRepository)
        {
            repository = animalRepository;
        }

        public IEnumerable<Animal> GetAll()
        {
            return repository.GetAll();
        }

        public AnimalResponse Save(Animal animal)
        {
            try
            {
                repository.Add(animal);
                return new AnimalResponse(animal);
            }
            catch (Exception ex)
            {
                return new AnimalResponse($"An error occurred when saving the animal: {ex.Message}");
            }
        }
    }
}
