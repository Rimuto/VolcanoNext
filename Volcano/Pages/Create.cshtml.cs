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
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Text;

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

            // string[] cars = File.ReadAllLines(@"C:\Cars.csv");
            //Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
            // Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open("C:\\Users\\Rimuto\\source\\repos\\Volcano\\Volcano\\Res\\¬улканы.xlsx", Type.Missing, true);


            //DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader("C:\\Users\\Rimuto\\source\\repos\\Volcano\\Volcano\\Res\\Vulkano1.csv", Encoding.UTF8))
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
                    for (int i = 0; i < headers.Length; i++)
                    {
                        //dr[i] = rows[i];
                    }
                    //dt.Rows.Add(dr);
                }

            }

            //ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохран€€
            //ObjWorkExcel.Quit(); // выйти из эксел€
            //GC.Collect(); // убрать за собой
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
