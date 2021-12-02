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
    public class NaudojaController : Controller
    {
        private readonly iskkContext _context;
        private IEnumerable<SelectListItem> avalyne;
        private IEnumerable<SelectListItem> medziagos;
        public NaudojaController(iskkContext context)
        {
            _context = context;
            avalyne  = _context.Avalynės.Select(d =>
               new SelectListItem
               {
                   Value = d.IndividualusNumeris.ToString(),
                   Text = d.IndividualusNumeris.ToString()
               });
            medziagos =  _context.Medžiagas.Select(d =>
              new SelectListItem
              {
                  Value = d.IdMedžiaga.ToString(),
                  Text = d.Pavadinimas
              });
        }


        [Route("Database/Naudoja/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Naudojas.Where(d => d.FkAvalynėindividualusNumeris.ToString() == id) ;
                
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Naudojas.ToList().Count;
                return View(_context.Naudojas.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Naudoja>());
        }


        [HttpPost]
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }


        [Route("Database/Naudoja/Add")]
        public ActionResult Add()
        {
            ViewBag.Av = avalyne;
            ViewBag.Me = medziagos;
            return View();
        }

        [Route("Database/Naudoja/Add")]
        [HttpPost]
        public ActionResult Add(Naudoja mod)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Av = avalyne;
                ViewBag.Me = medziagos;
                return View();
            }
            try
            {
                _context.Naudojas.Add(mod);
                _context.SaveChanges();
            }
            catch
            {
                ViewBag.Av = avalyne;
                ViewBag.Me = medziagos;
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
        [Route("Database/Naudoja/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Naudojas.Remove(_context.Naudojas.FirstOrDefault(m => m.id == id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Error"] = "Add failed. Relation already exists.";
            }

            return RedirectToAction("Index");
        }








        //[Route("Database/Naudoja/Edit")]
        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Av = avalyne;
        //    ViewBag.Me = medziagos;
        //    return View(_context.Naudojas.FirstOrDefault(m => m.id == id));
        //}

        //[HttpPost]
        //[Route("Database/Naudoja/Edit")]
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
