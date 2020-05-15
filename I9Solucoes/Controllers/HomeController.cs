using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;

namespace I9Solucoes.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Logar(string email, string senha)
		{
			var resultado = new UsuarioRepository().Autenticar(email, senha);
			if (resultado)
			{
				HttpCookie cookie = new HttpCookie("login");
								cookie.Value = "logado";
				HttpContext.Response.Cookies.Add(cookie);
			}
			return Json(resultado,JsonRequestBehavior.AllowGet);
		}
	}
}