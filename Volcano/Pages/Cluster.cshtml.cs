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

namespace Volcano.Pages
{
    public class ClusterModel : PageModel
    {
        public Volcanos Vulka { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPostClaster()
        {
            return new JsonResult(Vulka);
        }
    }
}
