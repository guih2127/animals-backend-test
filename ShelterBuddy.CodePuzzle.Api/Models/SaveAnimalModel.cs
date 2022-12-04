namespace ShelterBuddy.CodePuzzle.Api.Models
{
    public class SaveAnimalModel
    {
        public string? Name { get; init; }
        public string? Color { get; init; }
        public string? MicrochipNumber { get; init; }
        public string? Species { get; set; }
        public DateTime? DateOfBirth { get; init; }
        public DateTime? DateInShelter { get; init; }
        public DateTime? DateLost { get; init; }
        public DateTime? DateFound { get; init; }
        public int? AgeYears { get; init; }
        public int? AgeMonths { get; init; }
        public int? AgeWeeks { get; init; }
    }
}
