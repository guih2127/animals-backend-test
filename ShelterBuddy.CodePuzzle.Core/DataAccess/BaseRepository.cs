using ShelterBuddy.CodePuzzle.Core.Contexts;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.DataAccess;

public class BaseRepository<T, TKey> : IRepository<T, TKey>
    where T : BaseEntity<TKey>, IAuditable
    where TKey : IEquatable<TKey>
{
    protected readonly AppDbContext _context;
    private IAuditStamper auditStamper = new AuditStamper();

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public T? GetEntity(TKey id) =>
        _context.Set<T>().Find(id);

    public IQueryable<T> GetAll() => _context.Set<T>();

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    private class AuditStamper : IAuditStamper
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public string Name => "Test";
    }
}