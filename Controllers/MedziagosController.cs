using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using decaf.Models;
using decaf.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace decaf.Controllers
{
    public class MedziagosController : Controller
    {
        private readonly iskkContext _context;
        public MedziagosController(iskkContext context)
        {
            _context = context;
        }


        [Route("Database/Medziagos/{id?}")]
        public ActionResult Index(string id)
        {
            if (id != null && id.All(char.IsDigit))
            {
                var diz = _context.Medžiagas.Where(d => d.IdMedžiaga.ToString() == id);
                ViewBag.count = diz.ToList().Count;
                return View(diz);
            }
            else if (id == null)
            {
                ViewBag.count = _context.Medžiagas.ToList().Count;
                return View(_context.Medžiagas.ToList());
            }
            ViewBag.count = 0;
            return View(new List<Medžiaga>());
        }


        [HttpPost] 
        public ActionResult ShowDB(string psl, string id)
        {
            return RedirectToAction("index", psl, new { id });
        }

        [Route("Database/Medziagos/Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("Database/Medziagos/Add")]
        [HttpPost]
        public ActionResult Add(Medžiaga medz)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Medžiagas.Add(medz);
            _context.SaveChanges();

            // Skaiciuojams pridetu elementu kiekis i sesija
            var sv = HttpContext.Session.GetInt32("add_cnt") ?? 0;
            HttpContext.Session.SetInt32("add_cnt", sv + 1);
            //---------------------------------------------

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Database/Medziagos/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Medžiagas.Remove(_context.Medžiagas.Find(id));
                _context.SaveChanges();
            }
            catch
            {
                TempData["Err"] = "Delete failed. Entry has relations with other entries.";
            }
            
            return RedirectToAction("Index");
        }

        [Route("Database/Medziagos/Edit")]
        public ActionResult Edit(int id)
        {
            return View(_context.Medžiagas.Find(id));
        }

        [HttpPost]
        [Route("Database/Medziagos/Edit")]
        public ActionResult Edit(int id, Medžiaga medz)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Update(medz);
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
