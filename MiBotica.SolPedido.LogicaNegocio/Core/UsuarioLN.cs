using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return new UsuarioDA().ListaUsuarios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().InsertarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            try
            {
                return new UsuarioDA().ObtenerUsuarioPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            try
            {
                new UsuarioDA().EditarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditarUsuarioClave(Usuario usuario)
        {
            try
            {
                new UsuarioDA().EditarUsuarioClave(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                new UsuarioDA().EliminarUsuario(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarUsuario(Usuario Usuario)
        {
            try
            {
                return new UsuarioDA().BuscarUsuario(Usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }


        public Usuario BuscarUsuarioPorCodUsuarioYClave(string codUsuario, byte[] clave)
        {
            try
            {
                return new UsuarioDA().BuscarUsuarioPorCodUsuarioYClave(codUsuario, clave);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
