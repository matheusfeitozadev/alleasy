using System.Threading.Tasks;
using AllEasy.API.Context;
using AllEasy.API.Interfaces;
using AllEasy.API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AllEasy.API.Services
{
    public class ProdutoRepository : IGeneric<Produto>
    {
        private readonly ContextDB _contextDB;

        public ProdutoRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<Produto> Add(Produto model)
        {
            _contextDB.Produtos.Add(model);
            await _contextDB.SaveChangesAsync();

            return await Task.FromResult(model);
        }

        public async Task Delete(int Id)
        {
            var produto = _contextDB.Produtos.FirstOrDefault(x=> x.IdProduto == Id);

            _contextDB.Entry(produto).State = EntityState.Deleted;
            await _contextDB.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _contextDB.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int Id)
        {
            return await _contextDB.Produtos.FirstOrDefaultAsync(x=> x.IdProduto == Id);
        }

        public async Task<Produto> Update(Produto model)
        {
            var produto = _contextDB.Produtos.FirstOrDefault(x=> x.IdProduto == model.IdProduto);

            produto.Nome = model.Nome;
            produto.Descricao = model.Descricao;
            produto.Preco = model.Preco;
            produto.Quantidade = model.Quantidade;
            produto.Ativo = model.Ativo;

            _contextDB.Entry(produto).State = EntityState.Modified;
            await _contextDB.SaveChangesAsync();

            return await Task.FromResult(produto);
        }
    }
}