using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Livro> Livros = DB.Livros.ToList();
            return View(Livros);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            List<Autor> lAutores = DB.Autores.ToList();
            List<Categoria> lCategorias = DB.Categorias.ToList();

            List<SelectListItem> listaAutores = lAutores.ConvertAll(a =>
            {
               return new SelectListItem()
               {
                   Text = a.Nome,
                   Value = a.Id.ToString(),
                   Selected = false
               };
            });

            List<SelectListItem> listaCategorias = lCategorias.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });

            @ViewBag.Autores = listaAutores;
            @ViewBag.Categorias = listaCategorias;

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

                    return RedirectToAction("Index");
                }
                return View(livro);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
