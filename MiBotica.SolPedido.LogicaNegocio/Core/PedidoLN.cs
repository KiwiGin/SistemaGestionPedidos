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
    }
}
