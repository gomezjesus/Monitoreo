using NewsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitoreoModels;

namespace WebApplication.Controllers
{
    public class DiarioController : Controller
    {
        // GET: Diario
        public ActionResult Index()
        {
            var diarios = DiarioRepository.GetDiarios();
            return View(diarios);
        }

        // GET: Diario/Details/5
        public ActionResult Details(int id)
        {
            var diario = DiarioRepository.GetDiario(id);
            return View(diario);
        }

        // GET: Diario/Create
        public ActionResult Create()
        {
            return View(new DiarioImpreso());
        }

        // POST: Diario/Create
        [HttpPost]
        public ActionResult Create(DiarioImpreso diario)
        {
            try
            {
                bool success = DiarioRepository.InsertDiario(diario);
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

        // GET: Diario/Edit/5
        public ActionResult Edit(int id)
        {
            var diario = DiarioRepository.GetDiario(id);
            return View(diario);
        }

        // POST: Diario/Edit/5
        [HttpPost]
        public ActionResult Edit(DiarioImpreso diario)
        {
            try
            {
                bool success = DiarioRepository.UpdateDiario(diario);
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

        // GET: Diario/Delete/5
        public ActionResult Delete(int id)
        {

            var diario = DiarioRepository.GetDiario(id);
            return View(diario);
        }

        // POST: Diario/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                bool success = DiarioRepository.DeleteDiario(id);
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
