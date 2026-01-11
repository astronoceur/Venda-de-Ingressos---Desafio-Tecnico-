using MeuProjeto.Api.Models;

namespace MeuProjeto.Api.Services;

public class FilmeService
{
    private readonly List<Filme> _filmes = new()
    {
        new Filme { Id = 1, Titulo = "Avatar 2", Sala = "Sala 1", Horario = "19:00" },
        new Filme { Id = 2, Titulo = "Interestelar", Sala = "Sala 2", Horario = "21:00" },
        new Filme { Id = 3, Titulo = "Homem-Aranha", Sala = "Sala 3", Horario = "18:30" }
    };

    public IEnumerable<Filme> Listar()
    {
        return _filmes;
    }

    public Filme? ObterPorId(int id)
    {
        return _filmes.FirstOrDefault(f => f.Id == id);
    }
}
