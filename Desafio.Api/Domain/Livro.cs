using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// MongoDB.Serialization é associada a criação de tipos especiais quando construímos classes que estarão associadas a uma coleção na base MongoDB.

namespace Desafio.Api
{
    public class Livro
    {
        // A propriedade Id será para o MongoDB object string, e não string. É um tipo especial que somente o MongoDB manipula.
        // É necessário indicar ao programa que id será um ObjectId
        [BsonRepresentation(BsonType.ObjectId)]  // Essa sentença irá criar o campo id contido em cada coleção de uma base MongoDB.
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }
    }
}


