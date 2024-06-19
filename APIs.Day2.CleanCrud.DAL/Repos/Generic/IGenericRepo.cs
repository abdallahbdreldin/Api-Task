namespace APIs.Day2.CleanCrud.DAL;

public interface IGenericRepo<TEntity>
    where TEntity : class
{
    List<TEntity> GetAll();
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
}