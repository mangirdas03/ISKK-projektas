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
    public class SamdoController : Controller
    {
        private readonly iskkContext _context;
        private IEnumerable<SelectListItem> dizaineris;
        private IEnumerable<SelectListItem> gamintojas;
        public SamdoController(iskkContext context)
        {
            _context = context;
            dizaineris = _context.Dizaineris.Select(d =>
              new SelectListItem
              {
                  Value = d.AsmensKodas.ToString(),
                  Text = d.Pavardė.ToString()
              });
            gamintojas = _context.Gamintojas.Select(d =>
             new SelectListItem
             {
                 Value = d.IdGamintojas.ToString(),
                 Text = d.Pavadinimas
             });
        }


        [Route("Database/Samdo/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Samdos.Where(d => d.FkDizainerisasmensKodas.ToString() == id);

                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Samdos.ToList().Count;
                return View(_context.Samdos.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Samdo>());
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }


        [Route("Database/Samdo/Add")]
        public ActionResult Add()
        {
            ViewBag.Di = dizaineris;
            ViewBag.Ga = gamintojas;
            return View();
        }

        [Route("Database/Samdo/Add")]
        [HttpPost]
        public ActionResult Add(Samdo mod)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Di = dizaineris;
                ViewBag.Ga = gamintojas;
                return View();
            }
            try
            {
                _context.Samdos.Add(mod);
                _context.SaveChanges();
            }
            catch
            {
                ViewBag.Di = dizaineris;
                ViewBag.Ga = gamintojas;
                TempData["Error"] = "Add failed. Relation already exists.";
                return View("add");
            }


            // Skaiciuojams pridetu elementu kiekis i sesija
            var sv = HttpContext.Session.GetInt32("add_cnt") ?? 0;
            HttpContext.Session.SetInt32("add_cnt", sv + 1);
            //---------------------------------------------

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Database/Samdo/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Samdos.Remove(_context.Samdos.FirstOrDefault(m => m.id == id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }

            return RedirectToAction("Index");
        }








        //[Route("Database/Samdo/Edit")]
        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Av = avalyne;
        //    ViewBag.Me = medziagos;
        //    return View(_context.Naudojas.FirstOrDefault(m => m.id == id));
        //}

        //[HttpPost]
        //[Route("Database/Samdo/Edit")]
        //public ActionResult Edit(int id, Naudoja mod)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Av = avalyne;
        //        ViewBag.Me = medziagos;
        //        return View();
        //    }
        //    try
        //    {
        //        _context.Update(mod);
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        ViewBag.Av = avalyne;
        //        ViewBag.Me = medziagos;
        //        TempData["Error"] = "Edit failed. Entry has relations with other entries.";
        //        return View("edit");
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}
