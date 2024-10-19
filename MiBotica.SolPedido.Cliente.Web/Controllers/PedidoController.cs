using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using Newtonsoft.Json;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class PedidoController : Controller
    {
        string RutaApi = "https://localhost:44337/api/"; // define la ruta de la Api
        string jsonMediaType = "application/json"; // define el tipo de dato
        // GET: Pedido
        public ActionResult Index()
        {
            string metodo = "Pedido"; //refiere al controlador del la Api
            List<Pedido> lista = new List<Pedido>();
            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear(); // borra datos anterioes de la cabecera
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación textos en chino ñ y otros
                string rutacompleta = RutaApi + metodo;
                var data = cliente.DownloadString(new Uri(rutacompleta));
                lista = JsonConvert.DeserializeObject<List<Pedido>>(data);
            }
            return View(lista);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
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

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
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
