using Agenda.DB.Config.Interface;
using Agenda.Web.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Agenda.DB.Config.Service
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Contato> _contatos;

        public MongoDBService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("MongoDBSettings:ConnectionString").Value);
            _database = client.GetDatabase(configuration.GetSection("MongoDBSettings:DatabaseName").Value);
            _contatos = _database.GetCollection<Contato>("Contatos");
        }

        public IEnumerable<Contato> GetContatos(FilterDefinition<Contato> filter = null)
        {
            if (filter == null)
            {
                return _contatos.Find(contato => true).ToList();
            }
            return _contatos.Find(filter).ToList();
        }

        public Contato GetContatoById(string id)
        {
            return _contatos.Find<Contato>(contato => contato.Id == id).FirstOrDefault();
        }

        public Contato CreateContato(Contato contato)
        {
            _contatos.InsertOne(contato);
            return contato;
        }

        public void UpdateContato(string id, Contato contatoIn)
        {
            _contatos.ReplaceOne(contato => contato.Id == id, contatoIn);
        }

        public void RemoveContato(string id)
        {
            _contatos.DeleteOne(contato => contato.Id == id);
        }
    }
}

