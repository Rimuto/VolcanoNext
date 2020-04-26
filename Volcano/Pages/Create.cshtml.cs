using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volcano.Models;
using Microsoft.Extensions.Logging;

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
            //Volcanos order = _context.Vulk
            //    .Where(o => o.Name == Vulka.Name)
            //    .FirstOrDefault();
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
