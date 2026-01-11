using MeuProjeto.Api.Models;

namespace MeuProjeto.Api.Services;

public class ReservaService
{

    private readonly Dictionary<int, List<Assento>> _salas = new();

    private readonly Dictionary<int, List<Reserva>> _reservas = new();

    private List<Assento> CriarSalaSeNaoExistir(int filmeId)
    {
        if (_salas.ContainsKey(filmeId))
            return _salas[filmeId];

        var assentos = new List<Assento>();
        int id = 1;

        for (int linha = 1; linha <= 5; linha++)
        {
            for (int coluna = 1; coluna <= 8; coluna++)
            {
                assentos.Add(new Assento
                {
                    Id = id++,
                    Linha = linha,
                    Coluna = coluna,
                    Status = StatusAssento.LIVRE
                });
            }
        }

        _salas[filmeId] = assentos;
        _reservas[filmeId] = new List<Reserva>();

        return assentos;
    }

    public IEnumerable<Assento> ObterAssentos(int filmeId)
    {
        return CriarSalaSeNaoExistir(filmeId);
    }

    public bool ReservarAssento(int filmeId, int assentoId, string email)
    {
    var sala = CriarSalaSeNaoExistir(filmeId);
    var reservas = _reservas[filmeId];

    var assento = sala.FirstOrDefault(a => a.Id == assentoId);
    if (assento == null) return false;
    if (assento.Status != StatusAssento.LIVRE) return false;

    // Não pode sentar ao lado de assento OCUPADO
    var vizinhoEsquerda = sala.FirstOrDefault(a =>
        a.Linha == assento.Linha &&
        a.Coluna == assento.Coluna - 1
    );

    var vizinhoDireita = sala.FirstOrDefault(a =>
        a.Linha == assento.Linha &&
        a.Coluna == assento.Coluna + 1
    );

    if ((vizinhoEsquerda?.Status == StatusAssento.OCUPADO) ||
        (vizinhoDireita?.Status == StatusAssento.OCUPADO))
    {
        return false; 
    }

    assento.Status = StatusAssento.RESERVADO;

    reservas.Add(new Reserva
    {
        FilmeId = filmeId,
        AssentoId = assentoId,
        UsuarioEmail = email,
        ExpiraEm = DateTime.UtcNow.AddMinutes(2)
    });

    return true;
    }

    public bool ConfirmarCompra(int filmeId, int assentoId, string email)
    {
        var reservas = _reservas[filmeId];
        var sala = _salas[filmeId];

        var reserva = reservas.FirstOrDefault(r =>
            r.AssentoId == assentoId &&
            r.UsuarioEmail == email
        );

        if (reserva == null) return false;

        var assento = sala.First(a => a.Id == assentoId);
        assento.Status = StatusAssento.OCUPADO;

        reservas.Remove(reserva);
        return true;
    }

    public bool CancelarReserva(int filmeId, int assentoId, string email)
    {
        var reservas = _reservas[filmeId];
        var sala = _salas[filmeId];

        var reserva = reservas.FirstOrDefault(r =>
            r.AssentoId == assentoId &&
            r.UsuarioEmail == email
        );

        if (reserva == null) return false;

        var assento = sala.First(a => a.Id == assentoId);
        assento.Status = StatusAssento.LIVRE;

        reservas.Remove(reserva);
        return true;
    }

    public void LiberarExpirados()
    {
        foreach (var filme in _reservas.Keys)
        {
            var reservas = _reservas[filme];
            var sala = _salas[filme];

            var expiradas = reservas
                .Where(r => r.ExpiraEm <= DateTime.UtcNow)
                .ToList();

            foreach (var reserva in expiradas)
            {
                var assento = sala.First(a => a.Id == reserva.AssentoId);
                assento.Status = StatusAssento.LIVRE;
                reservas.Remove(reserva);
            }
        }
    }
}