using Utils;

namespace ShelterBuddy.CodePuzzle.Core.Entities;

public class Animal : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Color { get; set; }
    public string? Species { get; set; }
    public string? MicrochipNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateInShelter { get; set; }
    public DateTime? DateLost { get; set; }
    public DateTime? DateFound { get; set; }
    public int? AgeYears { get; set; }
    public int? AgeMonths { get; set; }
    public int? AgeWeeks { get; set; }

    public string? AgeText => SetAgeText();

    public string SetAgeText()
    {
        //TODO - Arrumar lógica com DateOfBirth
        if (DateOfBirth != null)
        {
            var (years, months, weeks) = DateTimeUtils.DateDiff(DateOfBirth.Value, DateTime.Now);
            return $"{years} years {months} months {weeks} weeks";
        }
        else if (AgeYears != null || AgeMonths != null || AgeWeeks != null)
        {
            var animalAge = String.Empty;

            if (AgeYears != null)
                animalAge += $" {AgeYears} years";
            if (AgeMonths != null)
                animalAge += $" {AgeMonths} months";
            if (AgeWeeks != null)
                animalAge += $" {AgeWeeks} weeks";

            if (animalAge[0] == ' ')
            {
                animalAge = animalAge.Remove(0, 1);
            }

            return animalAge;
        }

        return String.Empty;
    }
}