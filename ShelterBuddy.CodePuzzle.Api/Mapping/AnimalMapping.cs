using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Mapping
{
    public static class AnimalMapping
    {
        public static Animal MapModelToEntity(AnimalModel animal)
        {
            return new Animal
            {
                Id = Guid.NewGuid(),
                Name = animal.Name,
                Color = animal.Color,
                Species = animal.Species,
                DateFound = animal.DateFound,
                DateLost = animal.DateLost,
                MicrochipNumber = animal.MicrochipNumber,
                DateInShelter = animal.DateInShelter,
                DateOfBirth = animal.DateOfBirth,
                AgeMonths = animal.AgeMonths,
                AgeWeeks = animal.AgeWeeks,
                AgeYears = animal.AgeYears,
            };
        }

        public static AnimalModel MapEntityToModel(Animal animal)
        {
            return new AnimalModel
            {
                Id = animal.Id.ToString(),
                Name = animal.Name,
                Color = animal.Color,
                Species = animal.Species,
                DateFound = animal.DateFound,
                DateLost = animal.DateLost,
                MicrochipNumber = animal.MicrochipNumber,
                DateInShelter = animal.DateInShelter,
                DateOfBirth = animal.DateOfBirth,
                AgeMonths = animal.AgeMonths,
                AgeWeeks = animal.AgeWeeks,
                AgeYears = animal.AgeYears,
                AgeText = animal.AgeText
            };
        }
    }
}
