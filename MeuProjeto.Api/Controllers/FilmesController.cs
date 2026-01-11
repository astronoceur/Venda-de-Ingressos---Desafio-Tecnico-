using Microsoft.AspNetCore.Mvc;
using MeuProjeto.Api.Services;

namespace MeuProjeto.Api.Controllers;

[ApiController]
[Route("api/filmes")]
public class FilmesController : ControllerBase
{
    private readonly FilmeService _service;

    public FilmesController(FilmeService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_service.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var filme = _service.ObterPorId(id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
