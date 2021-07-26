using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEasy.API.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(int Id);
        Task<T> GetById(int Id);
    }
}