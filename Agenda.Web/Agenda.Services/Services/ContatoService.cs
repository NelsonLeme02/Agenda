using Agenda.DB.Config.Interface;
using Agenda.Services.Interfaces;
using Agenda.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Services.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IMongoDBService _mongoDBService;
        public ContatoService(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        public IEnumerable<Contato> BuscarTodos()
        {
            IEnumerable<Contato> retorno = _mongoDBService.GetContatos();
            return retorno;
        }
        public Contato Criar(Contato contato)
        {
            var contatoCriado = _mongoDBService.CreateContato(contato);
            return contatoCriado;
        }
        public Contato Buscar(Guid Id)
        {
            var contatoEncontrado = _mongoDBService.GetContatoById(Id.ToString());
            return contatoEncontrado;
        }
        public void Atualizar(Guid Id, Contato contato)
        {
            _mongoDBService.UpdateContato(Id.ToString(), contato);
        }
        public void Deletar(Guid Id)
        {
            _mongoDBService.RemoveContato(Id.ToString());
        }
    }
}
