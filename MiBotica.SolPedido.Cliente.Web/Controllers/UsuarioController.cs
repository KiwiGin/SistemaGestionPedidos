using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;


namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : BaseLN
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios();
            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Usuario usuario = new UsuarioLN().ObtenerUsuarioPorId(id);
                if (usuario != null)
                {
                    return View(usuario);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                // Registrar el error para obtener más detalles
                ModelState.AddModelError("", "Error al obtener los detalles del usuario: " + ex.Message);
                return View("Error");
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                new UsuarioLN().InsertarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Verificar si el error es porque el usuario ya existe
                if (ex.Message.Contains("ya existe"))
                {
                    ModelState.AddModelError("", "El usuario con el código ingresado ya existe.");
                }
                else
                {
                    ModelState.AddModelError("", "Error al crear el usuario: " + ex.Message);
                }

                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = new UsuarioLN().ObtenerUsuarioPorId(id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (usuario.ClaveTexto != null)
                    {
                        usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                        new UsuarioLN().EditarUsuarioClave(usuario);
                    }
                    else
                    {
                        usuario.Clave = null;
                        new UsuarioLN().EditarUsuario(usuario);
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Registrar el error para obtener más detalles
                    ModelState.AddModelError("", "Error al editar el usuario: " + ex.Message);
                    return View(usuario);
                }
            }
            // Si la validación falla, vuelve a mostrar la vista con los errores de validación
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = new UsuarioLN().ObtenerUsuarioPorId(id);
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                new UsuarioLN().EliminarUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
