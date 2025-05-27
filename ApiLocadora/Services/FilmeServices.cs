using ApiLocadora.Dtos;
using ApiLocadora.DataContext;
using ApiLocadora.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiLocadora.Services;

public class FilmeServices
{
    private readonly AppDbContext _context;
 
        public FilmeServices(AppDbContext context)
    { 
        _context = context;
    }
   
    public  ICollection<Filme> GetAll() 
    {
    
        var list = _context.Filmes.ToList();
        return list;

    }
    public async Task<Filme> CriarFilme(FilmeDtos item)
    {
        var data = item.AnoLancamento;
        var filme = new Filme
        {
            Nome = item.Nome,
            Genero = item.Genero,
            AnoLancamento = new DateOnly(data.Year, data.Month, data.Day)
        };
        await _context.Filmes.AddAsync(filme);
        await _context.SaveChangesAsync();
        return (filme);

    }
    public async Task<Filme> Atualizar(int id,FilmeDtos item)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) throw new BadHttpRequestException("Não Encontrado");
        filme.Nome = item.Nome;
        filme.Genero = item.Genero;


        return filme;
    }
    public async Task Remover(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            throw new BadHttpRequestException("Filme não encontrado.");
        }
        _context.Filmes.Remove(filme);
        return ;
    }



}


