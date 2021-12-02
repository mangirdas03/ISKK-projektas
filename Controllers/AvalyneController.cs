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
    public class AvalyneController : Controller
    {
        private readonly iskkContext _context;
        private IEnumerable<SelectListItem> modeliai;
        public AvalyneController(iskkContext context)
        {
            _context = context;
            modeliai = _context.Modelis.Select(d =>
            new SelectListItem
            {
                Value = d.IdModelis.ToString(),
                Text = d.Pavadinimas
            });
        }


        [Route("Database/Avalyne/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Avalynės.Where(d => d.IndividualusNumeris.ToString() == id);
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Avalynės.ToList().Count;
                return View(_context.Avalynės.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Avalynė>());
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }


        [Route("Database/Avalyne/Add")]
        public ActionResult Add()
        {
            ViewBag.Mod = modeliai;
            return View();
        }

        [Route("Database/Avalyne/Add")]
        [HttpPost]
        public ActionResult Add(Avalynė ava)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mod = modeliai;
                return View();
            }
            try
            {
                _context.Avalynės.Add(ava);
                _context.SaveChanges();
            }
            catch
            {
                TempData["Error"] = "Add failed. Bad ID in one of the fields.";

                ViewBag.Mod = modeliai;
                return View("add");
            }
            // Skaiciuojams pridetu elementu kiekis i sesija
            var sv = HttpContext.Session.GetInt32("add_cnt") ?? 0;
            HttpContext.Session.SetInt32("add_cnt", sv + 1);
            //---------------------------------------------

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Database/Avalyne/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Avalynės.Remove(_context.Avalynės.Find(id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }

            return RedirectToAction("Index");
        }

        [Route("Database/Avalyne/Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.Mod = modeliai;
            return View(_context.Avalynės.Find(id));
        }

        [HttpPost]
        [Route("Database/Avalyne/Edit")]
        public ActionResult Edit(int id, Avalynė ava)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mod = modeliai;
                return View();
            }
            try
            {
                _context.Update(ava);
                _context.SaveChanges();
            }
            catch
            {
                ViewBag.Mod = modeliai;
                TempData["Error"] = "Edit failed. Entry has relations with other entries.";
                return View("edit");
            }
            return RedirectToAction("Index");
        }
    }
}
