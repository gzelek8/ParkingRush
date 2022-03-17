namespace ParkingRush.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(string id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(T entity);
}