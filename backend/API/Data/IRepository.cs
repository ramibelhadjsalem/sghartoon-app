using System;
namespace API.Data
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<T> GetById(string id);
        Task Update(string id, T entity);
        Task Delete(string id);
        Task<List<T>> GetAll();

    }
}

