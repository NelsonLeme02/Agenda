
using Agenda.Web.Models;

namespace Agenda.Services.Interfaces
{
    public interface IContatoService
    {
        Contato Criar(Contato contato);
        Contato Buscar(string Id);
        void Atualizar(string Id, Contato contato);
        void Deletar(string Id);

    }
}
