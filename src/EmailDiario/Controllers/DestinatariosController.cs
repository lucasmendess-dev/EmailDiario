using EmailDiario.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailDiario.Controllers
{
    public class DestinatariosController : Controller
    {
        private readonly DestinatarioService _destinatarioService;

        public DestinatariosController(DestinatarioService destinatarioService)
        {
            _destinatarioService = destinatarioService;
        }

        public async Task<IActionResult> Index()
        {
            var destinatarios = await _destinatarioService.ListarTodosAsync();
            return View(destinatarios);
        }
    }
}