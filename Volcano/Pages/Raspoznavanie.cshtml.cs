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
        public List<Volcanos> Vulk { get; set; }//это чтобы что-то
        [BindProperty]
        public Volcanos Vulka { get; set; }
        public Raspoznavanie raspoz;

        public RaspoznavanieModel(ApplicationContext db)
        {
            _context = db;
            Vulk = _context.Vulk.AsNoTracking().ToList();
        }

        public void OnGet()
        {
            // results = _context.Vulk.ToList();
        }
        //для решения задачи распознавания
        public async Task<IActionResult> OnPostAsync()
        {
            int maslng = 0;
            //Vulka = new Volcanos();
            //количество строк в бд. Нужно для двухмерного массива
            var cntVulk = _context.Vulk.Count();
            //var cntPrisn = Vulk.

            //Console.WriteLine(cntVulk);

            int[] proper = new int[135];
            for (int i = 0; i < 135; i++)
            {
                PropertyInfo info = Vulka.GetType().GetProperty("P" + (i + 1));
                //info.SetValue();
                proper[i] = Convert.ToInt32(info.GetValue(Vulka));
                if (proper[i]==1)
                {
                    maslng++;
                }
            }




            int[] D = new int[maslng];
            for (int i = 0; i < maslng; i++)
            {
                D[i] = 1;
            }

            for (int i=0; i<135; i++)
            {

            }

            int[,] prisn = new int[cntVulk, maslng];
            int counter = 0;
            int coun = 0;



            foreach (Volcanos tmp in Vulk)
            {
                for (int j = 0; j < 135; j++)
                {
                    //Vulka = new Volcanos();
                    PropertyInfo info = tmp.GetType().GetProperty("P" + (j + 1));

                    if (proper[j] == 1)
                    { 
                        
                        prisn[counter, coun] = Convert.ToInt32(info.GetValue(tmp));
                        coun++;
                    }
                    //Console.WriteLine(" {0} ", prisn[counter, j]);
                }
                coun = 0;
                counter++;
            }







            int[] clq1 = { 16, 18 };
            int sum = 0;

            for(int i =0;i<clq1[0];i++ )
            {
                for (int j = clq1[0]; j < cntVulk; j++)
                {
                    for (int k=0; k< maslng;k++)
                    {
                        if (prisn[i, k] == prisn[j, k])
                            sum++;
                    }
                    if (sum==maslng)
                    {
                        for (int k = 0; k < maslng; k++)
                        {
                            prisn[j, k] = 999;
                        }
                    }
                    sum = 0;
                }
            }

            sum = 0;
            for (int i = 0; i < cntVulk; i++)
            {
                for (int k = 0; k < maslng; k++)
                {
                    if (prisn[i, k] == 0)
                        sum++;
                }
                if (sum == maslng)
                {
                    for (int k = 0; k < maslng; k++)
                    {
                        prisn[i, k] = 999;
                    }
                }
                sum = 0;
            }

            sum = 0;
            for (int i = 0; i < cntVulk; i++)
            {
                if (prisn[i, 0] == 999)
                    sum++;
            }

            int[,] prisn2 = new int[cntVulk-sum, maslng];
            int jo = 0;
            for (int i = 0; i < cntVulk; i++)
            {
                if (prisn[i, 0] != 999)
                {
                    for (int k = 0; k < maslng; k++)
                    {
                        prisn2[jo, k] = prisn[i, k];
                    }
                    jo++;
                }
            }

            clq1[0] = 16;
            clq1[1] = prisn2.GetLength(0) - 16;


            Raspoznavanie lol1 = new Raspoznavanie(clq1, prisn);
            answer = lol1.FindCluster(D);

            return null;
        }

        public IActionResult OnPostRaspos()
        {
            return new JsonResult(Vulk);
        }
    }
}