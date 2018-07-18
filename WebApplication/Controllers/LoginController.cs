using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitoreoModels;
using NewsDataAccess;
using System.Security.Cryptography;
using System.Text;
namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["user"] != null)
                Session["user"] = null;
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }
        public string Encrypt(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
            byte[] res = md5.Hash;
            StringBuilder str = new StringBuilder();
            for(int i = 0; i < res.Length; i++)
            {
                str.Append(res[i].ToString("x2"));
            }
            return str.ToString();
        }
        public ActionResult Enter(Usuario usuario)
        {
            usuario.Password = Encrypt(usuario.Password);
            bool exists = UsuarioRepository.VerifyUser(usuario);
            if (exists)
            {
                Session["user"] = UsuarioRepository.GetUsuario(usuario);
                return RedirectToAction("Index", "News");
            }
            else               
                return View("Index");           
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
