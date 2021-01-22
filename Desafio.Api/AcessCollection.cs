using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Desafio.Api
{
    class AcessCollection
    {
        private const string _uri = "mongodb://localhost:27017";
        private const string _nameDatabase = "Biblioteca";
        private const string _nameCollection = "Livros";
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Livro> _collection;
        private Livro _document;

        public AcessCollection() 
        {
            _client = new MongoClient(_uri);
            _database = _client.GetDatabase(_nameDatabase);
            _collection = _database.GetCollection<Livro>(_nameCollection);
        }

        public AcessCollection(Livro document)
        {
            _client = new MongoClient(_uri);
            _database = _client.GetDatabase(_nameDatabase);
            _collection = _database.GetCollection<Livro>(_nameCollection);
            _document = document;
        }

        public void CreateDocument()
        {
            _collection.InsertOne(_document);
        }

        public void ReadAllDocuments()
        {
            // Find(nenhum critério de busca, listando)
            var biblioteca = _collection.Find(new BsonDocument()).ToList();
            foreach (var livro in biblioteca)
            {
                Console.WriteLine(livro.ToJson<Livro>() + "\n");
            }

            Console.WriteLine("Fim da lista.");
        }

        public void ReadDocumentByFilter()
        {
            var constructor = Builders<Livro>.Filter;
            var condition = constructor.Eq(x => x.Titulo, "Dom Casmurro");

            // filtro por ano onde seja maior que 1999
            // var condition = constructor.Gte(x => x.Ano, 1999);

            // filtro por ano onde seja maior que 1999 e mais de 300 páginas
            //var condition = constructor.Gte(x => x.Ano, 1999) & constructor.Gte(x => x.Paginas, 300);

            // filtro por livro de ficcão cientifica
            // var condition = constructor.AnyEq(x => x.Assunto, "Ficcao Cientifica");

            var biblioteca = _collection.Find(condition).ToList();
            foreach (var livro in biblioteca)
            {
                Console.WriteLine(livro.ToJson<Livro>() + "\n");
            }

            Console.WriteLine("Documento encontrado por filtro!");
        }

        public void UpdateDocumment()
        {
            var constructor = Builders<Livro>.Filter;
            var fliterCondition = constructor.Eq(x => x.Titulo, "Dom Casmurro");

            var biblioteca = _collection.Find(fliterCondition).ToList();
            foreach (var livro in biblioteca)
            {
                Console.WriteLine(livro.ToJson<Livro>() + "\n");
            }

            Console.WriteLine("Registro encontrado!");

            var updateConstructor = Builders<Livro>.Update;
            var updateCondition = updateConstructor.Set(x => x.Ano, 2004);
            _collection.UpdateOne(fliterCondition, updateCondition);

            Console.WriteLine("Registro alterado!");
        }

        public void DeleteDocument()
        {

        }

    }
}
