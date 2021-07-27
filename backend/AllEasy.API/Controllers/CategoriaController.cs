using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllEasy.API.Context;
using AllEasy.API.Models;
using AllEasy.API.Repository;
using AllEasy.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllEasy.API.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(ContextDB contextDB)
        {
            _categoriaRepository = new CategoriaRepository(contextDB);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _categoriaRepository.GetAll();

            return Ok(list);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var item = await _categoriaRepository.GetById(Id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            var item = await _categoriaRepository.Add(categoria);

            return Ok(item);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Categoria categoria)
        {
            var item = await _categoriaRepository.Update(categoria);

            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoriaRepository.Delete(Id);

            return Ok();
        }
    }
}
