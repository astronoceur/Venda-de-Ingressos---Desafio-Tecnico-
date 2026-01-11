using Microsoft.AspNetCore.Mvc;
using MeuProjeto.Api.Services;

namespace MeuProjeto.Api.Controllers;

[ApiController]
[Route("api")]
public class ReservasController : ControllerBase
{
    private readonly ReservaService _service;

    public ReservasController(ReservaService service)
    {
        _service = service;
    }

    [HttpGet("assentos/{filmeId}")]
    public IActionResult ObterAssentos(int filmeId)
    {
        return Ok(_service.ObterAssentos(filmeId));
    }

    [HttpPost("reservas")]
    public IActionResult ReservarAssento([FromBody] ReservaRequest request)
    {
        var sucesso = _service.ReservarAssento(
            request.FilmeId,
            request.AssentoId,
            request.Email
        );

        if (!sucesso)
            return BadRequest("Assento indisponível");

        return Ok();
    }

    [HttpPost("reservas/confirmar")]
    public IActionResult Confirmar([FromBody] ReservaRequest request)
    {
        var ok = _service.ConfirmarCompra(
            request.FilmeId,
            request.AssentoId,
            request.Email
        );

        return ok ? Ok() : BadRequest();
    }

    [HttpPost("reservas/cancelar")]
    public IActionResult Cancelar([FromBody] ReservaRequest request)
    {
        var ok = _service.CancelarReserva(
            request.FilmeId,
            request.AssentoId,
            request.Email
        );

        return ok ? Ok() : BadRequest();
    }
}

public record ReservaRequest(
    int FilmeId,
    int AssentoId,
    string Email
);