using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using Newtonsoft.Json;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ClientesController : Controller
    {
        string RutaApi = "https://localhost:44337/api/"; // define la ruta de la Api
        string jsonMediaType = "application/json"; // define el tipo de dato
        // GET: Clientes
        public ActionResult Index()
        {
            string metodo = "Cliente"; //refiere al controlador del la Api
            List<Clientes> lista = new List<Clientes>();
            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear(); // borra datos anterioes de la cabecera
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación textos en chino ñ y otros
                string rutacompleta = RutaApi + metodo;
                var data = cliente.DownloadString(new Uri(rutacompleta));
                lista = JsonConvert.DeserializeObject<List<Clientes>>(data);
            }
            return View(lista);
        }


        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            string metodo = "Cliente"; // Controlador de la API
            Clientes cliente = new Clientes(); // Instancia de cliente para almacenar los detalles

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Clear(); // Limpiar encabezados
                webClient.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // Tipo de contenido
                webClient.Encoding = UTF8Encoding.UTF8; // Codificación UTF-8

                // Obtener los detalles del cliente a través de la API
                string rutacompleta = RutaApi + metodo + "/" + id;
                var data = webClient.DownloadString(new Uri(rutacompleta)); // Realizar la solicitud GET
                cliente = JsonConvert.DeserializeObject<Clientes>(data); // Deserializar los datos en el objeto Cliente
            }

            return View(cliente); // Retornar el cliente a la vista para mostrar sus detalles
        }


        // GET: Clientes/Create
        public ActionResult Create()
        {
            Clientes cliente = new Clientes();
            return View(cliente);
        }


        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                string metodo = "Cliente"; // controlador de la API

                using (WebClient webClient = new WebClient())
                {
                    // Limpiar los encabezados y definir el tipo de contenido
                    webClient.Headers.Clear();
                    webClient.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato JSON
                    webClient.Encoding = UTF8Encoding.UTF8; // codificación UTF-8

                    // Serializar el objeto Cliente a JSON
                    string jsonData = JsonConvert.SerializeObject(cliente);

                    // Enviar la solicitud POST al API
                    string url = RutaApi + metodo;
                    string response = webClient.UploadString(url, "POST", jsonData);
                }

                // Redirigir a la página de índice si la operación fue exitosa
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: podría registrar el error o mostrar un mensaje adecuado
                ModelState.AddModelError("", "Ocurrió un error al crear el cliente: " + ex.Message);
                return View(cliente);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            string metodo = "Cliente"; // controlador de la API
            string accion = "Get"; // acción para obtener el cliente
            Clientes Entcli = new Clientes();

            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear(); // limpiar encabezados
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de contenido
                cliente.Encoding = UTF8Encoding.UTF8; // decodificación UTF-8

                string rutacompleta = RutaApi + metodo + "/" + id; // URL completa con el ID
                var data = cliente.DownloadString(new Uri(rutacompleta)); // realizar la petición GET
                Entcli = JsonConvert.DeserializeObject<Clientes>(data); // deserializar los datos JSON en un objeto Clientes
            }

            return View(Entcli); // enviar el objeto a la vista para su edición
        }


        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes collection)
        {
            string metodo = "Cliente"; //refiere al controlador del la Api
            try
            {
                // TODO: Add update logic here
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anterioes de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificacion reconocimiento de carateres especiales.
                    var clienteJson = JsonConvert.SerializeObject(collection);// convierte a clase Cliente en una trama Json
                                                                              // forma 1
                    string rutacompleta = RutaApi + metodo + "/" + id;
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "Put", clienteJson);

                    // otra forma
                    // Uri rutacompleta = new Uri(RutaApi + metodo);
                    // var resultado = Cliente.UploadString(rutacompleta,Put,clienteJson);


                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)

            {
                var zz = ex.Message;
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            string metodo = "Cliente"; // controlador de la API
            Clientes cliente = new Clientes();

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Clear(); // limpiar encabezados
                webClient.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de contenido
                webClient.Encoding = UTF8Encoding.UTF8; // decodificación UTF-8

                // Obtener el cliente para mostrar sus datos antes de eliminarlo
                string rutacompleta = RutaApi + metodo + "/" + id;
                var data = webClient.DownloadString(new Uri(rutacompleta));
                cliente = JsonConvert.DeserializeObject<Clientes>(data); // deserializar datos
            }

            return View(cliente); // retornar el cliente para confirmar su eliminación
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            string metodo = "Cliente"; // controlador de la API
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Clear(); // limpiar encabezados
                    webClient.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de contenido
                    webClient.Encoding = UTF8Encoding.UTF8; // decodificación UTF-8

                    // Realizar la petición DELETE
                    string rutacompleta = RutaApi + metodo + "/" + id;
                    webClient.UploadString(new Uri(rutacompleta), "DELETE", string.Empty); // envío de DELETE sin contenido
                }

                return RedirectToAction("Index"); // Redirigir a la lista de clientes tras eliminar
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al eliminar el cliente: " + ex.Message);
                return View();
            }
        }

    }
}
