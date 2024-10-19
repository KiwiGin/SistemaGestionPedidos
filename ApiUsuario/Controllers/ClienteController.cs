using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;

namespace ApiUsuario.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly ClientesLN _clientesLN = new ClientesLN();

        // GET: api/Cliente
        public IEnumerable<Clientes> Get()
        {
            return _clientesLN.ListaClientes();
        }

        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
            var cliente = _clientesLN.BuscarClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody] Clientes value)
        {
            var clienteExistente = _clientesLN.BuscarClientePorId(value.Codigo);

            if (clienteExistente != null)
            {
                return BadRequest("Ya existe un cliente con el mismo código.");
            }

            var resultado = _clientesLN.InsertarCliente(value);

            if (resultado)
            {
                return Ok("Cliente agregado correctamente.");
            }

            return InternalServerError();
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody] Cliente value)
        {
            var clienteExistente = _clientesLN.BuscarClientePorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.NombreCompleto = value.NombreCompleto;
            clienteExistente.Zona = value.Zona;

            var resultado = _clientesLN.ModificarCliente(clienteExistente);

            if (resultado)
            {
                return Ok("Cliente actualizado correctamente.");
            }

            return InternalServerError();
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(int id)
        {
            var clienteExistente = _clientesLN.BuscarClientePorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            var resultado = _clientesLN.EliminarCliente(id);

            if (resultado)
            {
                return Ok("Cliente eliminado correctamente.");
            }

            return InternalServerError();
        }
    }
}
