using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class ClientesLN
    {
        private ClientesDA _clientesDA = new ClientesDA();

        public List<Clientes> ListaClientes()
        {
            try
            {
                return _clientesDA.ListaClientes();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public Clientes BuscarClientePorId(int codigo)
        {
            try
            {
                return _clientesDA.BuscarClientePorId(codigo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool InsertarCliente(Clientes cliente)
        {
            try
            {
                return _clientesDA.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool ModificarCliente(Clientes cliente)
        {
            try
            {
                return _clientesDA.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool EliminarCliente(int codigo)
        {
            try
            {
                return _clientesDA.EliminarCliente(codigo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }
    }
}
