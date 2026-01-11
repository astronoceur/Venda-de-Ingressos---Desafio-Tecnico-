namespace MeuProjeto.Api.Models;

public class Assento
{
    public int Id { get; set; }
    public int Linha { get; set; }
    public int Coluna { get; set; }
    public int FilmeId { get; set; } 
    public StatusAssento Status { get; set; } = StatusAssento.LIVRE;
}
