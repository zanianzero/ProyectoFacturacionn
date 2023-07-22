using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class DetalleFacturaController : Controller
    {
       
        private string Url = "https://facturasapi202307161115.azurewebsites.net/api/FactDetalleFacturas";
        private string Url1 = "https://facturasapi202307161115.azurewebsites.net/api/productos";

        public  ProyectoFacturacion.productos[] Productos()
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ");
            var json = api.DownloadString(Url1);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.productos[]>(json);
        }

        public  ProyectoFacturacion.productos ProductoElegido()
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ");
            var json = api.DownloadString(Url1);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.productos>(json);
        }
        private Crud<FactDetalleFactura> crud { get; set; }
        public DetalleFacturaController()
        {
            crud = new Crud<FactDetalleFactura>();
        }


        // GET: DetalleFacturaController
        public ActionResult Index()
        {
            //lista de tipos de detalle factura
            var datos = crud.Select(Url);

            return View(datos);
        }

        // GET: DetalleFacturaController/Details/5
        public ActionResult Details(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: DetalleFacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleFacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FactDetalleFactura datos)
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

        // GET: DetalleFacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: DetalleFacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FactDetalleFactura datos)
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

        // GET: DetalleFacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: DetalleFacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FactDetalleFactura datos)
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
