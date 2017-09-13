using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReceitasCulinarias.Dal;
using ReceitasCulinarias.Entity;

namespace ReceitasCulinarias.UI.Controllers
{
	public class TipoReceitaController : Controller
	{
		private MongoDBContext _context;
		public TipoReceitaController(MongoDBContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var dal = new TipoReceitaDal(_context);
			var itens = dal.Listar();
			return View(itens);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TipoReceita tipoReceita)
		{
			if (ModelState.IsValid)
			{
				var dal = new TipoReceitaDal(_context);
				dal.Cadastrar(tipoReceita);
				ViewBag.Mensagem = "Cadastro realizado com sucesso";
				return View(null);
			}
			else
			{
				ViewBag.Mensagem = "Favor verificar os dados inseridos";
				return View();
			}
		}
	}
}