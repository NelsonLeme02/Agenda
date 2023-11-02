
using Agenda.Web.Models;

namespace Agenda.Services.Interfaces
{
    public interface IContatoService
    {
        Contato Criar(Contato contato);
        IEnumerable<Contato> BuscarTodos();
        Contato Buscar(Guid Id);
        void Atualizar(Guid Id, Contato contato);
        void Deletar(Guid Id);

    }
}
