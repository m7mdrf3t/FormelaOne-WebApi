namespace ServiceLink.EF.Interfaces;

public interface IGenereicReposatory<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetbyID(Guid id);

    Task<bool> Add(T entity);

    Task<bool> Update(T entity);

    Task<bool> Delete(Guid id);
     

    
}