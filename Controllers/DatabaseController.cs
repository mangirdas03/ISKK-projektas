using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using decaf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace decaf.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly iskkContext _context;

        public DatabaseController(iskkContext context )
        {
            _context = context;
        }
        //public async Task<IActionResult> Index() => View(await _context.Avalynės.ToListAsync());

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }



        //public async Task<IActionResult> Details(int? id)
        //{
        //    if(id == null)
        //    {
        //        return NotFound();
        //    }

        //    var avalyne = await _context.Avalynės.FirstOrDefaultAsync(m => m.IndividualusNumeris == id);
        //    if(avalyne == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(avalyne);
        //}
    }
}
