using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class ClientesDA
    {
        public Clientes LlenarEntidad(IDataReader reader)
        {
            Clientes cliente = new Clientes();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Codigo"]))
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreCompleto"]))
                    cliente.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Zona'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Zona"]))
                    cliente.Zona = Convert.ToString(reader["Zona"]);
            }

            return cliente;
        }

        // Listar clientes
        public List<Clientes> ListaClientes()
        {
            List<Clientes> listaEntidad = new List<Clientes>();
            Clientes entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListarClientes", conexion))
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

        // Buscar cliente por ID
        public Clientes BuscarClientePorId(int codigo)
        {
            Clientes cliente = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBuscarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        cliente = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }
            return cliente;
        }

        // Insertar nuevo cliente
        public bool InsertarCliente(Clientes cliente)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paInsertarClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    comando.Parameters.AddWithValue("@Zona", cliente.Zona);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Modificar cliente
        public bool ModificarCliente(Clientes cliente)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paModificarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                    comando.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    comando.Parameters.AddWithValue("@Zona", cliente.Zona);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Eliminar cliente
        public bool EliminarCliente(int codigo)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBorrarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
