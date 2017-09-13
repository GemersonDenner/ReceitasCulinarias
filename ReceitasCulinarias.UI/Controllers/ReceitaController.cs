using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReceitasCulinarias.Dal;

namespace ReceitasCulinarias.UI.Controllers
{
    public class ReceitaController : Controller
    {
		private MongoDBContext _context;
		public ReceitaController(MongoDBContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }
    }
}