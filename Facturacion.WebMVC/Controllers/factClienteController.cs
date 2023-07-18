using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;

namespace Facturacion.WebMVC.Controllers
{
    public class factClienteController : Controller
    {


        private string Url = "https://facturasapi20230703113608.azurewebsites.net/api/FactClientes";

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
        public ActionResult Details(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View();
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
                return View();
            }
        }

        // GET: factClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View();
        }

        // POST: factClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FactCliente datos)
        {
            try
            {
                crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: factClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = crud.Select_ById(Url, id.ToString());
            return View();
        }

        // POST: factClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FactCliente datos)
        {
            try
            {
                crud.Delete(Url, id.ToString());    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
