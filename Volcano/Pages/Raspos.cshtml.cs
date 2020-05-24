using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class RasposModel : PageModel
    {
        public StringBuilder answer = new StringBuilder();
        private readonly ApplicationContext _context;
        public List<Volcanos> Vulk { get; set; }//это чтобы что-то
        public Volcanos Vulka { get; set; }
        public Raspoznavanie raspoz;

        public RasposModel(ApplicationContext db)
        {
            _context = db;
            Vulk = _context.Vulk.AsNoTracking().ToList();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
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
    }
}
