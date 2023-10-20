using Agenda.Web.Models;
using MongoDB.Driver;

namespace Agenda.DB.Config.Interface
{
    public interface IMongoDBService
    {
        IEnumerable<Contato> GetContatos(FilterDefinition<Contato> filter = null);
        Contato GetContatoById(string id);
        Contato CreateContato(Contato contato);
        void UpdateContato(string id, Contato contatoIn);
        void RemoveContato(string id);
    }
}

