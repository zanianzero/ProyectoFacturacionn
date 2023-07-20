using Facturacion.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoFacturacion;
using SQLitePCL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Facturacion.WebMVC.Controllers
{
    public class productosController : Controller
    {


        private string Url = "https://inventarioproductos.onrender.com/productos";

        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk3OTg2NTcsImV4cCI6MTY4OTg4NTA1N30.NP8xrg50oQbCygS-HJAu1rSSrz4EECKzGT96c31ZQKw");
            return httpClient;
        }

        private DbContext _context; // Reemplaza "ApplicationDbContext" por el contexto de tu base de datos local

       

        private Crud<productos> crud { get; set; }
      
        // GET: productosController
        public ActionResult Index()
        {
            using (HttpClient httpClient = GetHttpClient())
            {
                var response = httpClient.GetAsync(Url).Result;
                response.EnsureSuccessStatusCode();
                var dato = response.Content.ReadAsStringAsync().Result;
                var datos = JsonConvert.DeserializeObject<List<productos>>(dato);
                return View(datos);
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
                        _context.AddRange(productosList); // Corregir "product" a "Productos"
                        _context.SaveChanges();
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
