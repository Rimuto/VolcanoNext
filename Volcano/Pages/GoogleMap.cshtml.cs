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

namespace Volcano.Pages
{
    public class GoogleMapModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Volcanos> Vulk { get; set; } //это чтобы что-то

        public GoogleMapModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            Vulk = _context.Vulk.AsNoTracking().ToList();
            foreach (var hill in Vulk)
            {
                string coordinatesLat = Convert.ToString(hill.NL) + "." + Convert.ToString(hill.NLM);
                string coordinatesLng = Convert.ToString(hill.EL) + "." + Convert.ToString(hill.ELM);
                string info = hill.Name;
            }
        }
    }
}
