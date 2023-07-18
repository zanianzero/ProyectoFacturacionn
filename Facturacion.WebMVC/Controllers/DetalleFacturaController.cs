using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class DetalleFacturaController : Controller
    {
       
        private string Url = "https://facturasapi20230703113608.azurewebsites.net/api/FactDetalleFacturas";

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
            return View();
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
            return View();
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
