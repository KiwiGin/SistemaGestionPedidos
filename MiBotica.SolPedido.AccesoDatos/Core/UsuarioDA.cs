using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class UsuarioDA
    {
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
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

        public Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario(); reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdUsuario"]))
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Clave"]))
                {
                    // usuario.Clave  = reader["Clave"];
                }
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodUsuario"]))
                    usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombres"]))
                    usuario.Nombres = Convert.ToString(reader["Nombres"]);
            }

            return usuario;

        }

        public void InsertarUsuario(Usuario usuario)
        {
            // Verificar si el CodUsuario ya existe
            if (UsuarioExiste(usuario.CodUsuario))
            {
                throw new Exception("El usuario con el código " + usuario.CodUsuario + " ya existe.");
            }

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_insertar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@CodUsuario", usuario.CodUsuario));
                    comando.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuario.Nombres));

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }


        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_buscaId", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", id));
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }
            return entidad;
        }

        public void EditarUsuarioClave(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_editarclave", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", usuario.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    comando.Parameters.Add(new SqlParameter("@CodUsuario", usuario.CodUsuario));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuario.Nombres));
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_editar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", usuario.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@CodUsuario", usuario.CodUsuario));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuario.Nombres));
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public void EliminarUsuario(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_eliminar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", id));
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }

        }

        public bool UsuarioExiste(string codUsuario)
        {
            bool existe = false;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioExiste", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@CodUsuario", codUsuario));

                    SqlParameter returnParameter = new SqlParameter();
                    returnParameter.ParameterName = "@ReturnVal";
                    returnParameter.SqlDbType = SqlDbType.Int;
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add(returnParameter);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    int result = (int)comando.Parameters["@ReturnVal"].Value;
                    existe = result == 1; // 1 si el usuario existe, 0 si no existe
                }
                conexion.Close();
            }
            return existe;
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            Usuario SegSSOMUsuario = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {

                using (SqlCommand comando = new SqlCommand("paUsuario_BuscaCodUserClave", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        SegSSOMUsuario = LlenarEntidad(reader);

                    }

                    conexion.Close();
                }
            }
            return SegSSOMUsuario;
        }


        public Usuario BuscarUsuarioPorCodUsuarioYClave(string codUsuario, byte[] clave) {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_BuscaCodUserClave", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@CodUsuario", codUsuario));
                    comando.Parameters.Add(new SqlParameter("@Clave", clave));

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            CodUsuario = Convert.ToString(reader["CodUsuario"]),
                            Nombres = Convert.ToString(reader["Nombres"])
                        };
                        return usuario;
                    }
                }
            }
            return null;
        }
    }
}
