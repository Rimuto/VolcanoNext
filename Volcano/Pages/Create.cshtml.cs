using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volcano.Models;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Text;
using System.Reflection;

namespace Volcano.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Volcanos Vulka { get; set; }

        public CreateModel(ApplicationContext db)
        {
            _context = db;
        }

        public IEnumerable<Volcanos> results { get; set; }

        public void OnGet()
        {
           // results = _context.Vulk.ToList();
        }

        public IActionResult OnPostFillDB()
        {
            Nullable<bool> nu = null;
            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory+"\\Res\\Vulkano1.csv", Encoding.UTF8))
            {

                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    //dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    //DataRow dr = dt.NewRow();
                    Vulka.Name = rows[0];
                    Vulka.NL = Convert.ToInt32(rows[1] == ""?"0":rows[1]) ;
                    Vulka.NLM = Convert.ToInt32(rows[2] == "" ? "0" : rows[2]);
                    Vulka.EL = Convert.ToInt32(rows[3] == "" ? "0" : rows[3]);
                    Vulka.ELM = Convert.ToInt32(rows[4] == "" ? "0" : rows[4]);
                    for (int i = 1; i <= 135; i++)
                    {
                        PropertyInfo info = Vulka.GetType().GetProperty("P"+i);
                        //info.SetValue();
                        info.SetValue(Vulka, rows[i + 4] == "1" ? true: rows[i + 4] == ""? nu : false) ;
                        //var res = info.GetValue(Vulka);
                        //dr[i] = rows[i];
                    }
                    _context.Vulk.Add(Vulka);
                    _context.SaveChanges();
                    //dt.Rows.Add(dr);
                }

            }

            Console.WriteLine("111111111111111111111111111111111111111");
            return null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Vulk.Add(Vulka);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
