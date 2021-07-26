using System.Collections.Generic;
using System.Threading.Tasks;
using AllEasy.API.Models;

namespace AllEasy.API.Interfaces
{
    public interface IProduto
    {
        Task<List<Produto>> GetAll();
        Task<Produto> Add(Produto model);
        Task<Produto> Update(Produto model);
        Task Delete(int Id);
        Task<Produto> GetById(int Id);
    }
}