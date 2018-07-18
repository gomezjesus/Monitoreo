using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsModel;
using NewsDataAccess;
using MonitoreoModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetEvents()
        {
            string eventos = EventoRepository.GetEventos();
            return new JsonResult {Data= eventos, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpPost]
        public JsonResult Save(Evento e)
        {           
            if (e.EventID > 0)
            {
                bool success = EventoRepository.UpdateEvento(e);
            }
            else
            {
               bool success =  EventoRepository.AddEvento(e);
            }
            

            return new JsonResult { Data = new { status = true } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {            
            bool success = EventoRepository.DeleteEvent(id);
            return new JsonResult { Data = new { status = true } };
        }
    }
}