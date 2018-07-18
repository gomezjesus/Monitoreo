using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using NewsDataAccess;
using NewsModel;

using System.IO;

namespace WebApplication.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Index()
        {
            var notas = NewsRepository.GetNews();
            return View(notas);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            var nota = NewsRepository.GetNew(id);
            return View(nota);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            Nota nota = new Nota();
            nota.Secciones = new SelectList(SeccionRepository.GetSecciones(), "SeccionID", "NombreSeccion");
            nota.Categorias = new SelectList(CategoriaRepository.GetCategorias(), "CategoriaID", "NombreCategoria");
            nota.Diarios = new SelectList(DiarioRepository.GetDiarios(), "DiarioID", "Nombre");
            return View(nota);
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(Nota nota, HttpPostedFileBase file)
        {            
            Nota nota2 = new Nota();
            nota2.Secciones = new SelectList(SeccionRepository.GetSecciones(), "SeccionID", "NombreSeccion");
            nota2.Categorias = new SelectList(CategoriaRepository.GetCategorias(), "CategoriaID", "NombreCategoria");
            nota2.Diarios = new SelectList(DiarioRepository.GetDiarios(), "DiarioID", "Nombre");            
            if (ModelState.IsValid)
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string server_path = Path.Combine(Server.MapPath("~/Images"), filename);
                        file.SaveAs(server_path);
                        nota.Archivo = "~/Images/" + filename;
                    }
                    bool success = NewsRepository.InsertNota(nota);
                    if (success)
                        return RedirectToAction("Index");
                    else
                    {                        
                        return View();
                    }
                       
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return View();
                }
            }
            else
                return View(nota2);
        }
        [HttpPost]
        public ActionResult Find(string tags)
        {
            var notas = NewsRepository.FindNews(tags);
            return View("Index",notas);
        }
        
        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {

            var nota = NewsRepository.GetNew(id);           
            nota.Secciones = new SelectList(SeccionRepository.GetSecciones(), "SeccionID", "NombreSeccion");
            nota.Categorias = new SelectList(CategoriaRepository.GetCategorias(), "CategoriaID", "NombreCategoria");
            nota.Diarios = new SelectList(DiarioRepository.GetDiarios(), "DiarioID", "Nombre");
            return View(nota);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(Nota nota, HttpPostedFileBase file)
        {
            
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string server_path = Path.Combine(Server.MapPath("~/Images"), filename);
                    file.SaveAs(server_path);
                    nota.Archivo = "~/Images/" + filename;
                }
                bool success = NewsRepository.UpdateNota(nota);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View();
            }
        }

        // GET: News/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var nota = NewsRepository.GetNew(id);
            return View(nota);
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bool success = NewsRepository.DeleteNota(id);
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
