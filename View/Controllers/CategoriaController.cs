using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepository repository;
        //construtar tem objetivo inicializar objetos ou tipos primitivos necessarios para devido funcionamento da classe  sempre é executado o construtor ao instanticiar um objeto da classe ou seja ao fazer new categoriarepository()

        public CategoriaController()
        {
            repository = new CategoriaRepository();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            List<Categoria> categorias = repository.ObterTodos();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult  Store(string nome)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            repository.Inserir(categoria);
            return RedirectToAction("Index");

        }


    }
}