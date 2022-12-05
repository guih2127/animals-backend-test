using ShelterBuddy.CodePuzzle.Core.Contexts;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public class AnimalRepository : BaseRepository<Animal, Guid>
{
    public AnimalRepository(AppDbContext context) : base(context)
    {

    }
}