using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllEasy.API.Context;
using AllEasy.API.Interfaces;
using AllEasy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AllEasy.API.Repository
{
    public class CategoriaRepository : IGeneric<Categoria>
    {
        private readonly ContextDB _contextDB;

        public CategoriaRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<Categoria> Add(Categoria model)
        {
            _contextDB.Categorias.Add(model);
            await _contextDB.SaveChangesAsync();

            return await Task.FromResult(model);
        }

        public async Task Delete(int Id)
        {
            var categoria = _contextDB.Categorias.FirstOrDefault(x=> x.IdCategoria == Id);

            _contextDB.Entry(categoria).State = EntityState.Deleted;
            await _contextDB.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _contextDB.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetById(int Id)
        {
            return await _contextDB.Categorias.FirstOrDefaultAsync(x=> x.IdCategoria == Id);
        }

        public async Task<Categoria> Update(Categoria model)
        {
            var categoria = _contextDB.Categorias.FirstOrDefault(x=> x.IdCategoria == model.IdCategoria);

            categoria.Descricao = model.Descricao;
            categoria.Ativo = model.Ativo;

            _contextDB.Entry(categoria).State = EntityState.Modified;
            await _contextDB.SaveChangesAsync();

            return await Task.FromResult(categoria);
        }
    }
}