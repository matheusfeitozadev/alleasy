using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AllEasy.API.Services;
using AllEasy.API.Context;
using AllEasy.API.Models;

namespace AllEasy.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoService;

        public ProdutoController(ContextDB contextDB)
        {
            _produtoService = new ProdutoRepository(contextDB);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _produtoService.GetAll();

            return Ok(list);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var item = await _produtoService.GetById(Id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            var item = await _produtoService.Add(produto);

            return Ok(item);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Produto produto)
        {
            var item = await _produtoService.Update(produto);

            return Ok(item);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _produtoService.Delete(Id);

            return Ok();
        }
    }
}