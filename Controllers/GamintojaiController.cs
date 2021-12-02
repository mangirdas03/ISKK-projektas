using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using decaf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace decaf.Controllers
{
    public class GamintojaiController : Controller
    {
        private readonly iskkContext _context;
        public GamintojaiController(iskkContext context)
        {
            _context = context;
        }


        [Route("Database/Gamintojai/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Gamintojas.Where(d => d.IdGamintojas.ToString() == id);
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Gamintojas.ToList().Count;
                return View(_context.Gamintojas.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Gamintoja>());
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            //return RedirectToAction(psl, "database", new { id });
            return RedirectToAction("index", psl, new { id });
        }


        [Route("Database/Gamintojai/Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("Database/Gamintojai/Add")]
        [HttpPost]
        public ActionResult Add(Gamintoja gam)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Gamintojas.Add(gam);
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
        [Route("Database/Gamintojai/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Gamintojas.Remove(_context.Gamintojas.Find(id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }

            return RedirectToAction("Index");
        }

        [Route("Database/Gamintojai/Edit")]
        public ActionResult Edit(int id)
        {
            return View(_context.Gamintojas.Find(id));
        }

        [HttpPost]
        [Route("Database/Gamintojai/Edit")]
        public ActionResult Edit(int id, Gamintoja mod)
        {
            if (!ModelState.IsValid)
            {
                return View(_context.Gamintojas.Find(id));
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
