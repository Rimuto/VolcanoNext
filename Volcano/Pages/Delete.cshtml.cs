using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volcano.Models;
using Microsoft.EntityFrameworkCore;

namespace Volcano.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Volcanos Vulka { get; set; }
        public List<Volcanos> Vulk { get; set; }

        public DeleteModel(ApplicationContext db)
        {
            _context = db;
            Vulk = _context.Vulk.AsNoTracking().ToList();
            Console.WriteLine("111111111111111111111111111111111111111");
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostFranky()
        {
            //Volcanos order = _context.Vulk
            //    .Where(o => o.Name == Vulka.Name)
            //    .FirstOrDefault();
            string name = Request.Query["name"];
            var order = new Volcanos
            {
                Name = name
            };
            _context.Vulk.Remove(order);
            _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
