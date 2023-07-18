using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class FactFacturacionController : Controller
    {
        private string Url = "https://localhost:7161/api/FacFacturacion";

        private Crud<FacFacturacion> crud { get; set; }
        public FactFacturacionController()
        {
            crud = new Crud<FacFacturacion>();
        }
        // GET: Facturaciones
        public ActionResult Index()
        {
            //lista de tipos de factura cabecera   
            var datos = crud.Select(Url);
            return View(datos);

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
