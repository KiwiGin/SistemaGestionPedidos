using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.Entidades.Core
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string CodPedido { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
