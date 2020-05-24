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
using System.Text;

namespace Volcano.Pages
{
    public class RaspoznavanieModel : PageModel
    {
        public StringBuilder answer = new StringBuilder();
        private readonly ApplicationContext _context;
        [BindProperty]
        public List<Volcanos> Vulk { get; set; }//это чтобы что-то
        public Volcanos Vulka { get; set; }
        public Raspoznavanie raspoz;

        public RaspoznavanieModel(ApplicationContext db)
        {
            _context = db;
            Vulk = _context.Vulk.AsNoTracking().ToList();
        }

        //для решения задачи распознавания
        public async Task<IActionResult> OnPostAsync()
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
                    //Vulka = new Volcanos();
                    PropertyInfo info = tmp.GetType().GetProperty("P" + (j + 1));

                    prisn[counter, j] = Convert.ToInt32(info.GetValue(tmp));

                    Console.WriteLine(" {0} ", prisn[counter, j]);
                }
                counter++;
            }
            int[] clq1 = { 16, 18 };
            raspoz = new Raspoznavanie(clq1, prisn);

            //int maslng = 0;
            int[] proper = new int[135];
            for (int i = 0; i < 135; i++)
            {
                PropertyInfo info = Vulka.GetType().GetProperty("P" + (i + 1));
                //info.SetValue();
                proper[i] = Convert.ToInt32(info.GetValue(Vulka));
                if (proper[i] == 1)
                {
                    raspoz.FindCluster(proper);
                }
            }
            return null;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostRaspos()
        {
            return new JsonResult(Vulk);
        }
    }
}