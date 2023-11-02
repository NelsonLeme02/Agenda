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

        [HttpGet]
        public IActionResult BuscarContato(Guid IdContato)
        {
            try
            {
                var retorno = _contatoService.Buscar(IdContato);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o contato {ex}");
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var retorno = _contatoService.BuscarTodos();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o contato {ex}");
            }
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

        [HttpPut]
        public IActionResult AtualizarContato(Guid IdContato,Contato contato)
        {
            try
            {
                _contatoService.Atualizar(IdContato, contato);
                return Ok("Contato atualizado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o contato {ex}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteContato(Guid IdContato)
        {
            try
            {
                _contatoService.Deletar(IdContato);
                return Ok("Contato deletado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o contato {ex}");
            }
        }
    }
}
