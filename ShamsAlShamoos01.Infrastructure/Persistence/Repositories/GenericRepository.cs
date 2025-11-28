// نسخه بدون فیلتر و ترتیب
using Microsoft.EntityFrameworkCore;
using ShamsAlShamoos01.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;
public class GenericClass<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public GenericClass(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    // نسخه بدون فیلتر و ترتیب
    public IEnumerable<T> GetAll()
    {
        return _table.ToList();
    }

    // نسخه با فیلتر
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _table.Where(filter).ToList();
    }

    // نسخه با ترتیب
    public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        var query = _table.AsQueryable();
        query = orderBy(query);
        return query.ToList();
    }

    // نسخه با فیلتر و ترتیب
    public IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        IQueryable<T> query = _table;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query.ToList();
    }
}
