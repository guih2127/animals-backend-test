using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Responses
{
    public class AnimalResponse : BaseResponse
    {
        public Animal Animal { get; private set; }

        private AnimalResponse(bool success, string message, Animal animal) : base(success, message)
        {
            Animal = animal;
        }

        public AnimalResponse(Animal animal) : this(true, string.Empty, animal) { }

        public AnimalResponse(string message) : this(false, message, null) { }
    }
}
