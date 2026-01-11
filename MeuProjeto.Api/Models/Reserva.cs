namespace MeuProjeto.Api.Models;

public class Reserva
{
    public int FilmeId { get; set; }
    public int AssentoId { get; set; }
    public string UsuarioEmail { get; set; } = string.Empty;
    public DateTime ExpiraEm { get; set; }
}
