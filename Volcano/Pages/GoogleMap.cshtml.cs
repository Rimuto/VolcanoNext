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
using System.Text;

namespace Volcano.Pages
{
	public class GoogleMapModel : PageModel
	{
		struct DEATH
		{
			public string name;
			public int number;
			public bool[] props;
		}

		struct Enot
		{
			public int number;
			public int[] musk;
			public bool marked;
		}

		struct Enot2
		{
			public bool mak;
			public int num;
			public int[] number;
		}

		public StringBuilder answer = new StringBuilder();
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

		//Функция, вызываемая кнопкой
		public async Task<IActionResult> OnPostAsync()
		{
			int maslng = 0;
			bool[] proper = new bool[135];
			int x = Vulk.Count();
			List<DEATH> deat = new List<DEATH>();
			DEATH tempura = new DEATH();
			for (int i = 0; i < 135; i++)
			{
				PropertyInfo info = Vulka.GetType().GetProperty("P" + (i + 1));
				proper[i] = Convert.ToBoolean(info.GetValue(Vulka));
				if (proper[i] == true)
				{
					maslng++;
				}
			}

			foreach (Volcanos temp in Vulk)
			{
				tempura.props = new bool[maslng];
				tempura.name = temp.Name;
				tempura.number++;
				int ii = 0;
				for (int i = 0; i < 135; i++)
				{
					PropertyInfo info = temp.GetType().GetProperty("P" + (i + 1));
					if (proper[i] == true)
					{
						tempura.props[ii] = Convert.ToBoolean(info.GetValue(temp));
						ii++;
					}

				}
				deat.Add(tempura);
			}
			int[,] Mas = new int[x, maslng];
			int cy = 0;
			foreach (DEATH temp in deat)
			{
				for (int j = 0; j < maslng; j++)
				{
					Mas[cy, j] = Convert.ToInt32(temp.props[j]);
				}
				cy++;
			}

			int y = maslng;
			x = x - 1;
			int min = 10000;
			int z = 0;
			int R1 = y / 2 + y / 4;
			int R2 = R1;
			List<Enot> EnList = new List<Enot>();
			Enot en = new Enot();
			en.number = 0;
			en.musk = new int[y];
			for (int yy = 0; yy < y; yy++)
			{
				en.musk[yy] = Mas[0, yy];
			}
			EnList.Add(en);
			//int[,] Mas2 = new int[x, x];
			int SubSum = 0;
			for (int i = 0; i < EnList.Count(); i++)//примем за факт, что маски тут найдены
			{
				for (int xx = 0; xx < x; xx++)
				{
					foreach (Enot naruto in EnList)
					{
						SubSum = 0;
						for (int yy = 0; yy < y; yy++)
						{
							if (Mas[xx, yy] != naruto.musk[yy])
							{
								SubSum++;
							}
						}
						if (SubSum <= R1)
						{
							SubSum = 0;
							break;
						}
					}
					if (SubSum >= R1)
					{
						Enot enchik = new Enot();
						enchik.number = i + 1;
						enchik.musk = new int[13];
						for (int yy = 0; yy < y; yy++)
							enchik.musk[yy] = Mas[xx, yy];
						EnList.Add(enchik);
					}
					SubSum = 0;
				}
			}

			int[,] Mas2 = new int[x, EnList.Count()];

			for (int i = 0; i < EnList.Count(); i++)//примем за факт...
			{
				for (int xx = 0; xx < x; xx++)
				{
					SubSum = 0;
					for (int yy = 0; yy < y; yy++)
					{
						if (Mas[xx, yy] == EnList.ElementAt(i).musk[yy])
						{
							SubSum++;
						}
					}
					if (SubSum >= R2)
					{
						Mas2[xx, i] = 1;
					}
					if (SubSum < R2)
					{
						Mas2[xx, i] = 0;
					}
				}
			}

			List<Enot2> En2List = new List<Enot2>();
			int compadre = 0, coun = 0;
			for (int zz = 0; zz < x; zz++)// 
			{
				Enot2 Enotic = new Enot2();
				Enotic.num = zz + 1;
				Enotic.number = new int[x];
				coun = 0;
				for (int xx = zz + 1; xx < x; xx++)
				{
					compadre = 0;
					for (int yy = 0; yy < EnList.Count(); yy++)
					{
						if (Mas2[xx, yy] == Mas2[zz, yy])
							compadre++;
					}
					if (compadre == EnList.Count())
					{
						Enotic.number[coun] = xx + 1;
						coun++;
					}
				}
				En2List.Add(Enotic);
			}
			int[] a = En2List.ElementAt(0).number;
			for (int ju = 0; ju < En2List.Count; ju++)
			{
				int i = 0;
				for (int j = ju + 1; j < En2List.Count; j++)
				{
					if (En2List[j].num == En2List[ju].number[i])
					{
						Enot2 temp = new Enot2();
						temp = En2List[j];
						temp.mak = true;
						En2List[j] = temp;
						i++;
					}
				}
			}




			foreach (Enot2 enh in En2List)
			{
				if (enh.mak == false)
				{

					answer.Append(deat.Find(x => x.number.Equals(enh.num)).name + "; ");
					for (int i = 0; i < enh.number.Length; i++)
					{
						if (enh.number[i] != 0)
							answer.Append(deat.Find(x => x.number.Equals(enh.number[i])).name + "; ");
					}
					answer.Append(" \n ");
					answer.Append("++++++++++++++++++++++++++++++++++++++++++++++++++");
					answer.Append(" \n ");
				}
			}
			return null;
		}
		public IActionResult OnPostClaster()
		{
			return new JsonResult(Vulk);
		}

		public IActionResult OnGetHills()
		{
			//string name = Request.Query["name"];
			//var vuli = _context.Vulk.Where(b => b.Name == name).ToList();
			return new JsonResult(Vulk);
		}
	}
}
