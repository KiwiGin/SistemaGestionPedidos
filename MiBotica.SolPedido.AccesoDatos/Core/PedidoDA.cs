using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class PedidoDA
    {
        public Pedido LlenarEntidad(IDataReader reader)
        {
            Pedido pedido = new Pedido();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPedido'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodPedido"]))
                    pedido.CodPedido = Convert.ToString(reader["CodPedido"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreCompleto"]))
                    pedido.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Fecha"]))
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Estado"]))
                    pedido.Estado = Convert.ToString(reader["Estado"]);
            }

            return pedido;
        }

        // Listar pedidos
        public List<Pedido> ListaPedidos()
        {
            List<Pedido> listaEntidad = new List<Pedido>();
            Pedido entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListarPedidos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;

        }
        // Buscar pedido por ID
        public Pedido BuscarPedidoPorId(string codPedido)
        {
            Pedido pedido = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBuscarPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodPedido", codPedido);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        pedido = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }
            return pedido;
        }

        // Insertar nuevo pedido
        public bool InsertarPedido(Pedido pedido)
        {
  
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paInsertarPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodPedido", pedido.CodPedido);
                    comando.Parameters.AddWithValue("@NombreCompleto", pedido.NombreCompleto);
                    comando.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                    comando.Parameters.AddWithValue("@Estado", pedido.Estado);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                
            }
        }

        // Modificar pedido
        public bool ModificarPedido(Pedido pedido)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paModificarPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodPedido", pedido.CodPedido);
                    comando.Parameters.AddWithValue("@NombreCompleto", pedido.NombreCompleto);
                    comando.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                    comando.Parameters.AddWithValue("@Estado", pedido.Estado);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Eliminar pedido
        public bool EliminarPedido(string codPedido)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBorrarPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodPedido", codPedido);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
