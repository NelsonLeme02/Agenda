using Agenda.Services.Interfaces;
using Agenda.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Web.Controllers
{
    [Route("/Contato")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public HomeController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpPost]
        public IActionResult AdicionarContato(Contato contato)
        {
            try
            {
                var retorno = _contatoService.Criar(contato);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o contato {ex}");
            }
        }
    }
}
