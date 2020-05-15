using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;
using I9Solucoes.Models;
using I9Solucoes.Filtro;

namespace I9Solucoes.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        [PermissoesFilters]
        public ActionResult Index()
        {
            return View();
        }

[PermissoesFilters]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastra()
        {
            var fornecedor = new FornecedorRepository().Inserir(Request.Form["nome"], Request.Form["usuarioCadastro"], Request.Form["endereco"], Request.Form["cep"], Request.Form["uf"], Request.Form["cidade"], Request.Form["numero"], Request.Form["complemento"]);
            return Json(fornecedor, JsonRequestBehavior.AllowGet);
                        }

        [PermissoesFilters]
        public ActionResult Listar()
        {
            List<Fornecedor> fornecedor = new FornecedorRepository().Listar();
            return Json(fornecedor, JsonRequestBehavior.AllowGet);
        }
    }
}