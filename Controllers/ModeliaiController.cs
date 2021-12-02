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
    public class ModeliaiController : Controller
    {
        private readonly iskkContext _context;
        private IEnumerable<SelectListItem> dizaineriai;
        private IEnumerable<SelectListItem> gamintojai;
        public ModeliaiController(iskkContext context)
        {
            _context = context;
            dizaineriai  = _context.Dizaineris.Select(d =>
               new SelectListItem
               {
                   Value = d.AsmensKodas.ToString(),
                   Text = d.Pavardė
               });
            gamintojai =  _context.Gamintojas.Select(d =>
              new SelectListItem
              {
                  Value = d.IdGamintojas.ToString(),
                  Text = d.Pavadinimas
              });
        }


        [Route("Database/Modeliai/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Modelis.Where(d => d.IdModelis.ToString() == id);
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Modelis.ToList().Count;
                return View(_context.Modelis.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Modeli>());
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }


        [Route("Database/Modeliai/Add")]
        public ActionResult Add()
        {
            ViewBag.Di = dizaineriai;
            ViewBag.Ga = gamintojai;
            return View();
        }

        [Route("Database/Modeliai/Add")]
        [HttpPost]
        public ActionResult Add(Modeli mod)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Di = dizaineriai;
                ViewBag.Ga = gamintojai;
                return View();
            }
            try
            {
                _context.Modelis.Add(mod);
                _context.SaveChanges();
            }
            catch
            {
                ViewBag.Di = dizaineriai;
                ViewBag.Ga = gamintojai;
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
        [Route("Database/Modeliai/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Modelis.Remove(_context.Modelis.Find(id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }

            return RedirectToAction("Index");
        }

        [Route("Database/Modeliai/Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.Di = dizaineriai;
            ViewBag.Ga = gamintojai;
            return View(_context.Modelis.Find(id));
        }

        [HttpPost]
        [Route("Database/Modeliai/Edit")]
        public ActionResult Edit(int id, Modeli mod)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Di = dizaineriai;
                ViewBag.Ga = gamintojai;
                return View();
            }
            try
            {
                _context.Update(mod);
                _context.SaveChanges();
            }
            catch
            {
                ViewBag.Di = dizaineriai;
                ViewBag.Ga = gamintojai;
                TempData["Error"] = "Edit failed. Entry has relations with other entries.";
                return View("edit");
            }
            return RedirectToAction("Index");
        }

    }
}
