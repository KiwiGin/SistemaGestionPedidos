using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UbigeoController : Controller
    {
        // GET: Ubigeo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ubigeo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ubigeo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ubigeo/Create
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

        // GET: Ubigeo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ubigeo/Edit/5
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

        // GET: Ubigeo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ubigeo/Delete/5
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
