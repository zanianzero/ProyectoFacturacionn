using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Facturacion.WebMVC.Controllers
{
    public class FactFacturacionController : Controller
    {
        private string Url = "https://facturasapi202307161115.azurewebsites.net/api/FacFacturacion";

        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk3OTg2NTcsImV4cCI6MTY4OTg4NTA1N30.NP8xrg50oQbCygS-HJAu1rSSrz4EECKzGT96c31ZQKw");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk3MjA3MDYsImV4cCI6MTY4OTgwNzEwNn0.L1yB4dOxJV35HQjdlu4R3_VULz4ybRf0xCpsHFwzq4g");
            return httpClient;
        }

        private Crud<FacFacturacion> crud { get; set; }
        public FactFacturacionController()
        {
            crud = new Crud<FacFacturacion>();
        }
        // GET: Facturaciones
        public ActionResult Index()
        {
            //lista de tipos de factura cabecera   
            using (HttpClient httpClient = GetHttpClient())
            {
                var response = httpClient.GetAsync(Url).Result;
                response.EnsureSuccessStatusCode();
                var data = response.Content.ReadAsStringAsync().Result;
                var datos = JsonConvert.DeserializeObject<List<productos>>(data);
                return View(datos);
            }

        }

        // GET: FactFacturaCabeceraController/Details/5
        public ActionResult Details(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: FactFacturaCabeceraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactFacturaCabeceraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacFacturacion datos)
        {
            try
            {
                crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: FactFacturaCabeceraController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: FactFacturaCabeceraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FacFacturacion datos)
        {
            try
            {
                crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: FactFacturaCabeceraController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: FactFacturaCabeceraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FacFacturacion datos)
        {
            try
            {
                crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
