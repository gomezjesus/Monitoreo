using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitoreoModels;
using NewsDataAccess;
namespace WebApplication.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var categorias = CategoriaRepository.GetCategorias();
            return View(categorias);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            var categoria = CategoriaRepository.GetCategoria(id);
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View(new Categoria());
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                bool success = CategoriaRepository.InsertCategoria(categoria);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();                
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = CategoriaRepository.GetCategoria(id);
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                bool success = CategoriaRepository.UpdateCategoria(categoria);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = CategoriaRepository.GetCategoria(id);
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                bool success = CategoriaRepository.DeleteCategoria(id);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
