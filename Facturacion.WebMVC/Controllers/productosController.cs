using Facturacion.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoFacturacion;
using SQLitePCL;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Facturacion.WebMVC.Controllers
{
    public class productosController : Controller
    {


        private string Url = "https://inventarioproductos.onrender.com/productos";

        private string Url1 = "https://facturasapi202307161115.azurewebsites.net/api/productos";
        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ");
            return httpClient;
        }    

        private Crud<productos> crud { get; set; }


        public productosController()
        {

            crud = new Crud<productos>();
        }

        // ...otros métodos de controlador...

        public async Task<IActionResult> Index()
        {
            var datos=crud.Select(Url1); // Obtener los productos desde la base de datos local o donde sea
           
                return View(datos);
            
        }

        [HttpPost]
        public async Task<IActionResult> TransferirDatos()
        {
           try
            {

                // Crear un cliente HTTP
                using (HttpClient httpClient = new HttpClient())
                {
                    // Agregar el token de autenticación en el encabezado de autorización
                    string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Obtener los datos de la API externa
                    HttpResponseMessage response = await httpClient.GetAsync(Url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();

                    // Deserializar los datos en una lista de productos
                    List<productos> productosList = JsonConvert.DeserializeObject<List<productos>>(data);

                    // Enviar los datos a la base de datos local mediante una solicitud HTTP POST
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(productosList));
                    content.Headers.ContentType.MediaType = "application/json";

                    using (var localHttpClient = new HttpClient())
                    {
                        // Realizar la solicitud HTTP POST a la API local
                        HttpResponseMessage postResponse = await localHttpClient.PostAsync(Url1, content);
                        postResponse.EnsureSuccessStatusCode();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la transferencia de datos
                // Por ejemplo, registrar el error o mostrar un mensaje de error al usuario.
                return View("Error");
            }
       }

        // GET: productosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: productosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(productos datos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener los datos de la API externa
                    using (HttpClient httpClient = GetHttpClient())
                    {
                        var response = httpClient.GetAsync(Url).Result;
                        response.EnsureSuccessStatusCode();
                        var dato = response.Content.ReadAsStringAsync().Result;
                        var productosList = JsonConvert.DeserializeObject<List<productos>>(dato);
                        
                        // Insertar cada producto de la API externa en la base de datos local
                       
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la transferencia de datos
                    // Por ejemplo, registrar el error o mostrar un mensaje de error al usuario.
                    return View(datos);
                }
            }

            // Si el ModelState no es válido, regresar a la vista "Create" con los datos proporcionados
            return View(datos);
        }

        // GET: productosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: productosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: productosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
