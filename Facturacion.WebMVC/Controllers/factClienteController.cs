using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class factClienteController : Controller
    {


        private string Url = "https://facturasapi202307161115.azurewebsites.net/api/FactClientes";

        private Crud<FactCliente> crud { get; set; }
        public factClienteController()
        {
            crud = new Crud<FactCliente>();
        }



        // GET: factClienteController
        public ActionResult Index()
        {
            //lista de tipos de factura cabecera
            var datos = crud.Select(Url);
            return View(datos);
        }

        // GET: factClienteController/Details/5
        public ActionResult Details(string id)
        {
            var datos = crud.Select_ById(Url, id);
            return View(datos);
        }

        // GET: factClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: factClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FactCliente datos)
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

        // GET: factClienteController/Edit/5
        public ActionResult Edit(string id)
        {
            var datos = crud.Select_ById(Url, id);
            return View(datos);
        }

        // POST: factClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, FactCliente datos)
        {
            try
            {
                crud.Update(Url, id, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: factClienteController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = crud.Select_ById(Url, id);
            return View(datos);
        }

        // POST: factClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, FactCliente datos)
        {
            try
            {
                crud.Delete(Url, id);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
