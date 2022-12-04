using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Responses
{
    public class AnimalResponse : BaseResponse
    {
        public AnimalModel Animal { get; private set; }

        private AnimalResponse(bool success, string message, AnimalModel animal) : base(success, message)
        {
            Animal = animal;
        }

        public AnimalResponse(AnimalModel animal) : this(true, string.Empty, animal) { }

        public AnimalResponse(string message) : this(false, message, null) { }
    }
}
