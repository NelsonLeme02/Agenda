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

        public Contato Criar(Contato contato)
        {
            var contatoCriado = _mongoDBService.CreateContato(contato);
            return contatoCriado;
        }
        public Contato Buscar(string Id)
        {
            var contatoEncontrado = _mongoDBService.GetContatoById(Id);
            return contatoEncontrado;
        }
        public void Atualizar(string Id, Contato contato)
        {
            _mongoDBService.UpdateContato(Id, contato);
        }
        public void Deletar(string Id)
        {
            _mongoDBService.RemoveContato(Id);
        }
    }
}
