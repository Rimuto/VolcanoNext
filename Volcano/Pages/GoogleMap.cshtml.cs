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
		public Raspoznavanie raspoz;

		public GoogleMapModel(ApplicationContext db)
		{
			_context = db;
			Vulk = _context.Vulk.AsNoTracking().ToList();
		}

		public void OnGet()
		{

		}

		//для решения задачи распознавания
		public void Raspos()
		{
			//количество строк в бд. Нужно для двухмерного массива
			var cntVulk = _context.Vulk.Count();
			//var cntPrisn = Vulk.
			Console.WriteLine(cntVulk);

			int[,] prisn = new int[cntVulk, 135];
			int counter = 0;
			foreach (Volcanos tmp in Vulk)
			{
				for (int j = 0; j < 135; j++)
				{
					Vulka = new Volcanos();
					PropertyInfo info = tmp.GetType().GetProperty("P" + (j + 1));

					prisn[counter, j] = Convert.ToInt32(info.GetValue(tmp));

					Console.WriteLine(" {0} ", prisn[counter, j]);
				}
				counter++;
			}
			int[] clq1 = { 50, 85 };
			Raspoznavanie Raspos = new Raspoznavanie(clq1, prisn);

			Raspos.FindCluster()
		}

		public IActionResult OnGetPriznak()
		{
			return new JsonResult(Vulk);
		}

		public IActionResult OnGetHills()
		{
			Raspos();
			return new JsonResult(Vulk);
		}
	}
}
