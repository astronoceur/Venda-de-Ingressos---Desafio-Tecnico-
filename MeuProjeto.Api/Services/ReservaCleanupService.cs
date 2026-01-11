using Microsoft.Extensions.Hosting;
using MeuProjeto.Api.Services;

namespace MeuProjeto.Api.Services;

public class ReservaCleanupService : BackgroundService
{
    private readonly ReservaService _reservaService;

    public ReservaCleanupService(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _reservaService.LiberarExpirados();
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}
