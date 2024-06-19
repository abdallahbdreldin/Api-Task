namespace APIs.Day2.CleanCrud.DAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity>
   where TEntity : class
{
    private readonly HospitalContext _context;

    public GenericRepo(HospitalContext context)
    {
        _context = context;
    }

    public List<TEntity> GetAll()
    {
       return _context.Set<TEntity>()
            .ToList();
    }

    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>()
            .Find(id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>()
            .Add(entity);   
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>()
            .Update(entity);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
