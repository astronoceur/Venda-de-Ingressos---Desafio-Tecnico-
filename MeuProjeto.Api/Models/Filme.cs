namespace MeuProjeto.Api.Models;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Sala { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
}
