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


namespace Volcano.Pages
{
	public class GoogleMapModel : PageModel
	{
		private readonly ApplicationContext _context;
		[BindProperty]
		public Volcanos Vulka { get; set; }
		public List<Volcanos> Vulk { get; set; } //это чтобы что-то

		public GoogleMapModel(ApplicationContext db)
		{
			_context = db;
			Vulk = _context.Vulk.AsNoTracking().ToList();
		}

		public void OnGet()
		{

		}

		public IActionResult OnGetHills()
		{
			//string name = Request.Query["name"];
			//var vuli = _context.Vulk.Where(b => b.Name == name).ToList();
			return new JsonResult(Vulk);
		}
	}
}
