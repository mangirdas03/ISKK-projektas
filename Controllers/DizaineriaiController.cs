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
    public class DizaineriaiController : Controller
    {
        private readonly iskkContext _context;
        public DizaineriaiController(iskkContext context)
        {
            _context = context;
        }

        [Route("Database/Dizaineriai/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Dizaineris.Where(d => d.AsmensKodas.ToString() == id);
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Dizaineris.ToList().Count;
                return View(_context.Dizaineris.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Dizaineri>());
        }

        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            //return RedirectToAction(psl, "database", new { id });
            return RedirectToAction("index", psl, new { id });
        }

        [Route("Database/Dizaineriai/Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("Database/Dizaineriai/Add")]
        [HttpPost]
        public ActionResult Add(Dizaineri diz)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Dizaineris.Add(diz);
                _context.SaveChanges();
            }
            catch
            {
                TempData["Error"] = "Add failed. Bad ID in one of the fields.";
                return View("add");
            }
            // Skaiciuojams pridetu elementu kiekis i sesija
            var sv = HttpContext.Session.GetInt32("add_cnt") ?? 0;
            HttpContext.Session.SetInt32("add_cnt", sv + 1);
            //---------------------------------------------

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Database/Dizaineriai/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Dizaineris.Remove(_context.Dizaineris.Find(id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }

            return RedirectToAction("Index");
        }

        [Route("Database/Dizaineriai/Edit")]
        public ActionResult Edit(int id)
        {
            return View(_context.Dizaineris.Find(id));
        }

        [HttpPost]
        [Route("Database/Dizaineriai/Edit")]
        public ActionResult Edit(int id, Dizaineri mod)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Update(mod);
                _context.SaveChanges();
            }
            catch
            {
                TempData["Error"] = "Edit failed. Entry has relations with other entries.";
                return View("edit");
            }
            return RedirectToAction("Index");
        }

    }
}
