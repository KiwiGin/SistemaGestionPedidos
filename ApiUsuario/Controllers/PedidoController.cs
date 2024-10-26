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

        // GET: api/Cliente/5
        public IHttpActionResult Get(string id)
        {
            var pedidos = _pedidosLN.BuscarPedidoPorId(id);
            if (pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody] Pedido value)
        {
            var pedidoExistente = _pedidosLN.BuscarPedidoPorId(value.CodPedido);

            if (pedidoExistente != null)
            {
                return BadRequest("Ya existe un pedido con el mismo código.");
            }

            var resultado = _pedidosLN.InsertarPedido(value);

            if (resultado)
            {
                return Ok("Pedido agregado correctamente.");
            }

            return InternalServerError();
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(string id, [FromBody] Pedido value)
        {
            var pedidoExistente = _pedidosLN.BuscarPedidoPorId(id);

            if (pedidoExistente == null)
            {
                return NotFound();
            }
            pedidoExistente.CodPedido = value.CodPedido;
            pedidoExistente.NombreCompleto = value.NombreCompleto;
            pedidoExistente.Fecha = value.Fecha;
            pedidoExistente.Estado = value.Estado;

            var resultado = _pedidosLN.ModificarPedido(pedidoExistente);

            if (resultado)
            {
                return Ok("Pedido actualizado correctamente.");
            }

            return InternalServerError();
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(string id)
        {
            var pedidoExistente = _pedidosLN.BuscarPedidoPorId(id);

            if (pedidoExistente == null)
            {
                return NotFound();
            }

            var resultado = _pedidosLN.EliminarPedido(id);

            if (resultado)
            {
                return Ok("Pedido eliminado correctamente.");
            }

            return InternalServerError();
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
