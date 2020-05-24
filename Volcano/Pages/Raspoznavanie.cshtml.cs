﻿using System;
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
    public class RaspoznavanieModel : PageModel
    {
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

            int maslng = 0;
            bool[] proper = new bool[135];
            for (int i = 0; i < 135; i++)
            {
                PropertyInfo info = Vulka.GetType().GetProperty("P" + (i + 1));
                //info.SetValue();
                proper[i] = Convert.ToBoolean(info.GetValue(Vulka));
                if (proper[i] == true)
                {
                    maslng++;
                }
                //Raspos.FindCluster(Convert.ToInt32(proper[i]));
            }
        }

        public void OnGet()
        {

        }
    }
}