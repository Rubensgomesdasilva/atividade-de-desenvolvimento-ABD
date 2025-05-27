using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.DataContext;
using ApiLocadora.Models;
using Microsoft.EntityFrameworkCore;
using ApiLocadora.Services;

namespace ApiLocadora.Controllers
{
    [Route("Filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
     
        private readonly FilmeServices _services;

        public FilmeController(FilmeServices services)
        {
           _services = services;
        }

        [HttpGet]
        public async Task<IActionResult>  Buscar()
        {
            var listFilmes = _services.GetAll();
            return Ok(listFilmes);

        }

        [HttpPost]
        public async Task<IActionResult> CriarFilme([FromBody] FilmeDtos item)
        {
            var Filmes = await _services.CriarFilme(item);
            return Created("", Filmes);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar( int id, [FromBody] FilmeDtos item)
        {
           var Filmes = await _services.Atualizar(id, item);

            return Ok(); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover( int id)
        {
            await _services.Remover(id);

            return Ok("Filme removido com sucesso!");
        }       
    }
}
