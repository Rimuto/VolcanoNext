using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volcano.Models;

namespace Volcano.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Volcanos Vulka { get; set; }
        public List<Volcanos> Vulk { get; set; }
       //public string namet;

        public UpdateModel(ApplicationContext db)
        {
            _context = db;
            Vulk = _context.Vulk.AsNoTracking().ToList();
            Console.WriteLine("111111111111111111111111111111111111111");
        }

        public void OnGet()
        {
           //Vulk = _context.Vulk.AsNoTracking().ToList();
        }
        
        public JsonResult OnGetFranky()
        {
            //Console.WriteLine("sdhfgjsdhgfjshdgfjsdhgfjsdgfjshgd");
            string name = Request.Query["name"];
            var vuli = _context.Vulk.Where(b => b.Name == name).ToList();
            
            //string has = "sdasd0;0";
            return new JsonResult(vuli);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var volcanoToUpdate = await _context.Vulk.FindAsync(Vulka.Name);

            //if (volcanoToUpdate == null)
            //{
            //    return NotFound();
            //}
            // await _context.Vulk.Update(Vulka);
            //Vulka.Name = namet;
            if (ModelState.IsValid)
            {
                _context.Vulk.Update(Vulka);

                // Save changes in database
                await _context.SaveChangesAsync();
                //context.Attach(person);
                //context.Entry(person).Property("Name").IsModified = true;
                //context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

