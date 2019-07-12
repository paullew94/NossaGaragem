using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class VeiculoController : Controller
    {
        private VeiculoRepository repository;
        public VeiculoController()
        {
            repository = new VeiculoRepository();
        }
        // GET: Veiculo
        public ActionResult Index()
        {
            List<Veiculo> veiculos = repository.ObterTodos();
            ViewBag.Veiculos = veiculos;
            return View();
        }
        public ActionResult Cadastro()
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos();
            ViewBag.Categorias = categorias;
            return View();
        }
        public ActionResult Store(string modelo,int categoria,decimal valor)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Modelo = modelo;
            veiculo.IdCategoria = categoria;
            veiculo.Valor = valor;
            repository.Inserir(veiculo);
            return RedirectToAction("Index");
        }
    }
}