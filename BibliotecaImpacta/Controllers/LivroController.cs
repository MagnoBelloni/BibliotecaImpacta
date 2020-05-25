using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Helpers;
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
    public class LivroController : Controller
    {
        private BibliotecaDB DB = new BibliotecaDB();
        // GET: Livro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Livro/Details/5
        public ActionResult Details()
        {
            List<Livro> livros = DB.Livros.Include("Categoria").ToList();
            return View(livros);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            @ViewBag.Autores = RetornaSelectListItem.Autores();
            @ViewBag.Categorias = RetornaSelectListItem.Categorias();

            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    DB.Livros.Add(livro);
                    DB.SaveChanges();

                    return RedirectToAction("Details");
                }
                @ViewBag.Autores = RetornaSelectListItem.Autores();
                @ViewBag.Categorias = RetornaSelectListItem.Categorias();

                return View(livro);
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id.Equals(0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = DB.Livros.Find(id);

            @ViewBag.Autores = RetornaSelectListItem.Autores();
            @ViewBag.Categorias = RetornaSelectListItem.Categorias();


            return View(livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    DB.Livros.AddOrUpdate(livro);
                    DB.SaveChanges();
                    return RedirectToAction("Details");
                }

                @ViewBag.Autores = RetornaSelectListItem.Autores();
                @ViewBag.Categorias = RetornaSelectListItem.Categorias();

                return View(livro);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ContentResult Delete(int id)
        {
            var livro = DB.Livros.Find(id);
            DB.Livros.Attach(livro);
            DB.Livros.Remove(livro);
            DB.SaveChanges();
            return Content("Livro excluido com sucesso");
        }

    }
}
