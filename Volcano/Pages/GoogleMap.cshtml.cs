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
		public List<Volcanos> Vulk { get; set; } //это чтобы что-то
		[BindProperty]
		public Volcanos Vulka { get; set; }

		public GoogleMapModel(ApplicationContext db)
		{
			_context = db;
			Vulk = _context.Vulk.AsNoTracking().ToList();
		}

		public void OnGet()
		{

		}

		//public List<Volcanos> GetProperties(List<Volcanos> hill)
		//{
		//	hill = _context.Vulk.AsNoTracking().ToList();
		//	return hill;

		//	//foreach (var hill in Vulk)
		//	//{
		//	//	//var Name = hill.Name;
		//	//	//var EL = hill.EL;
		//	//	//var ELM = hill.ELM;
		//	//	//var NL = hill.NL;
		//	//	//var NLM = hill.NLM;
		//	//}
		//}
		public IActionResult OnPostFranky()
		{
			string name = Request.Query["name"];
			var order = new Volcanos
			{
				Name = name
			};
			_context.Vulk.Find(order);
			return RedirectToPage("GoogleMap");
		}
	}
}
