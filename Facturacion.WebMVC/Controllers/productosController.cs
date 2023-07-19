using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoFacturacion;

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
        // GET: productosController
        public ActionResult Index()
        {
            using (HttpClient httpClient = GetHttpClient())
            {
                var response = httpClient.GetAsync(Url).Result;
                response.EnsureSuccessStatusCode();
                var data = response.Content.ReadAsStringAsync().Result;
                var datos = JsonConvert.DeserializeObject<List<productos>>(data);
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
        public ActionResult Create(IFormCollection collection)
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
