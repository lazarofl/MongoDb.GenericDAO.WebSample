using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modal;
using System.Web.Configuration;

namespace MongoDb.GenericDAO.WebSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var postagens = new MongoDbGenericDao.MongoDBGenericDao<Postagem>(WebConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);

            //retorna os 10 últimos registros
            return View(postagens.GetAll().OrderByDescending(x => x.CriadoEm).Take(10).ToList());
        }


        [HttpPost]
        public ActionResult NovaPostagem(string Titulo, string Conteudo, string Autor)
        {
            Postagem novapostagem = new Postagem
            {
                Titulo = Titulo,
                Conteudo = Conteudo,
                Autor = new Autor
                {
                    Nome = Autor
                },
                CriadoEm = DateTime.Now.ToUniversalTime()
            };


            var postagens = new MongoDbGenericDao.MongoDBGenericDao<Postagem>(WebConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);

            //adiciona a postagem e redireciona para a página principal
            postagens.Save(novapostagem);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Remover(string Id)
        {
            var postagens = new MongoDbGenericDao.MongoDBGenericDao<Postagem>(WebConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);

            //obtem a postagem a partir do ID
            var postagem = postagens.GetByID(Id);

            //remove a postagem
            postagens.Delete(postagem);
            return RedirectToAction("Index");
        }

        public ActionResult Visualizar(string Id)
        {
            var postagens = new MongoDbGenericDao.MongoDBGenericDao<Postagem>(WebConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);

            //obtem a postagem a partir do ID
            var postagem = postagens.GetByID(Id);
            return View(postagem);

        }
    }
}
