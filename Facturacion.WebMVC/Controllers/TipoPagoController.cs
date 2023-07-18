using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class TipoPagoController : Controller
    {
        private string Url = "https://facturasapi20230703113608.azurewebsites.net/api/FactTipoPagos";

        private Crud<FactTipoPago> crud { get; set; }
        public TipoPagoController()
        {
            crud = new Crud<FactTipoPago>();
        }



        // GET: TipoPagoController
        public ActionResult Index()
        {
            //lsita de tipos de pago
            var datos= crud.Select(Url);
            return View(datos);
          
        }

        // GET: TipoPagoController/Details/5
        public ActionResult Details(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }
         
        // GET: TipoPagoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FactTipoPago datos)
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

        // GET: TipoPagoController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: TipoPagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FactTipoPago datos)
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

        // GET: TipoPagoController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: TipoPagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FactTipoPago datos)
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
