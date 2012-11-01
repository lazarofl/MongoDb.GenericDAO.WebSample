using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbGenericDao;

namespace Modal
{
    public class Postagem : MongoDBEntity
    {
        public DateTime CriadoEm { get; set; }
        public Autor Autor { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
