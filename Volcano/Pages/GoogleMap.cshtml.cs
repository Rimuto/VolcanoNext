using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volcano.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Reflection.Metadata;
using Microsoft.Data.Sqlite;

namespace Volcano.Pages
{
	public class GoogleMapModel : PageModel
	{
		private readonly ApplicationContext _context;
		[BindProperty]
		public List<Volcanos> Vulk { get; set; }//это чтобы что-то
		public Volcanos Vulka { get; set; }

		public GoogleMapModel(ApplicationContext db)
		{
			_context = db;
			Vulk = _context.Vulk.AsNoTracking().ToList();
		}

		public void OnGet()
		{

		}

        public IActionResult OnGetPriznak()
		{
			return new JsonResult(Vulk);
		}

		public IActionResult OnGetHills()
		{
			return new JsonResult(Vulk);
		}
	}
}
