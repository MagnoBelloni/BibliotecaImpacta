using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class CategoriaController : Controller
    {
        private BibliotecaDB DB = new BibliotecaDB();

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                DB.Categorias.Add(categoria);
                DB.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(categoria);
        }

        public ActionResult Details()
        {
            var categorias = DB.Categorias.ToList();
            return View(categorias);
        }

        public ActionResult Edit(int Id)
        {
            if (Id.Equals(0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Categoria = DB.Categorias.Find(Id);
            return View(Categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Categorias.AddOrUpdate(categoria);
                    DB.SaveChanges();
                    return RedirectToAction("Details");
                }
                return View(categoria);
            }
            catch 
            {
                return View();
            }
        }

        [HttpPost]
        public ContentResult Delete(int id)
        {
            var categoria = DB.Categorias.Find(id);
            DB.Categorias.Attach(categoria);
            DB.Categorias.Remove(categoria);
            DB.SaveChanges();
            return Content("Categoria Excluida com sucesso");
        }

    }
}