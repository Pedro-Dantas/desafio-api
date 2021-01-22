using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Desafio.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            //Livro livro = new Livro() 
            //{
            //    Titulo = "Dom Casmurro",
            //    Autor = "Machado de Assis",
            //    Ano = 1923,
            //    Paginas = 188,
            //    Assunto = new List<string>() { "Romance", "Literatura Brasileira" }
            //};

            var acessCollection = new AcessCollection();
            //acessCollection.ReadDocumentByFilter();
            acessCollection.UpdateDocumment();
        }
    }
}
