using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class AutorController : Controller
    {
        private BibliotecaDB DB = new BibliotecaDB();
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                DB.Autores.Add(autor);
                DB.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(autor);
        }

        public ActionResult Edit(int id)
        {
            Autor autor = DB.Autores.Find(id);
            if(autor.Id == 0)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                DB.Autores.AddOrUpdate(autor);
                DB.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(autor);
        }

        public ActionResult Details()
        {
            var autores = DB.Autores.ToList();

            return View(autores);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var autor = DB.Autores.Find(Id);
            DB.Autores.Attach(autor);
            DB.Autores.Remove(autor);
            DB.SaveChanges();
            return Content($"Autor '{autor.Nome}' excluido com sucesso!");
        }
    }
}