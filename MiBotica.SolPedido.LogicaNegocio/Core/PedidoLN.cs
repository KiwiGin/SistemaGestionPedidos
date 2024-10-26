using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class PedidoLN
    {
        private PedidoDA _pedidoDA = new PedidoDA();

        public List<Pedido> ListaPedidos()
        {
            try
            {
                return _pedidoDA.ListaPedidos();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public Pedido BuscarPedidoPorId(string codigo)
        {
            try
            {
                return _pedidoDA.BuscarPedidoPorId(codigo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool InsertarPedido(Pedido pedido)
        {
            try
            {
                return _pedidoDA.InsertarPedido(pedido);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool ModificarPedido(Pedido pedido)
        {
            try
            {
                return _pedidoDA.ModificarPedido(pedido);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }

        public bool EliminarPedido(string codigo)
        {
            try
            {
                return _pedidoDA.EliminarPedido(codigo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw;
            }
        }
    }
}
