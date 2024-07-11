using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DestinoCertoMVC.Controllers
{
    public class PacotesController : Controller
    {
        private readonly DCDbContext _context;

        public PacotesController(DCDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarPacote(PacoteViewModel pacote)
        {
            if (ModelState.IsValid)
            {
                // Obtendo o ID do usuário autenticado
                var usuarioId = User
                    .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                    ?.Value;

                if (int.TryParse(usuarioId, out int parsedUsuarioId))
                {
                    var novoPacote = new PacoteViewModel
                    {
                        Nome = pacote.Nome,
                        Origem = pacote.Origem,
                        Destino = pacote.Destino,
                        Atrativos = pacote.Atrativos,
                        Saida = pacote.Saida,
                        Retorno = pacote.Retorno,
                        UsuarioId = parsedUsuarioId
                    };

                    _context.Pacotes.Add(novoPacote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MenuUsuario", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao obter o ID do usuário.");
                }
            }
            return RedirectToAction("MenuUsuario", "Home", pacote);
        }
    }
}
