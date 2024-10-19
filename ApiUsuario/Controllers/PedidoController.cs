using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;

namespace ApiUsuario.Controllers
{
    public class PedidoController : ApiController
    {
        private readonly PedidoLN _pedidosLN = new PedidoLN();
        // GET: api/Pedido
        public IEnumerable<Pedido> Get()
        {
            return _pedidosLN.ListaPedidos();
        }

        //// GET: Pedido/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Pedido/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Pedido/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Pedido/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Pedido/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Pedido/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Pedido/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
