using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Volcano.Models;
using Microsoft.EntityFrameworkCore;

namespace Volcano.Pages
{
    public class ShowModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Volcanos> Vulk { get; set; }
        public ShowModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            Vulk = _context.Vulk.AsNoTracking().ToList();
        }
    }
}
