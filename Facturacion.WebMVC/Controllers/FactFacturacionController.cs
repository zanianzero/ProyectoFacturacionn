using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.UAPI;
using Microsoft.AspNetCore.JsonPatch.Internal;
using ProyectoFacturacion;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Policy;

namespace Facturacion.WebMVC.Controllers
{
    public class FactFacturacionController : Controller
    {
        private string UrlFact = "https://facturasapi202307161115.azurewebsites.net/api/FacFacturacion";

        private string UrlPro = "https://facturasapi202307161115.azurewebsites.net/api/productos";

        private string UrlCli = "https://facturasapi202307161115.azurewebsites.net/api/FactClientes";
        private string UrlTipo = "https://facturasapi202307161115.azurewebsites.net/api/FactTipoPagos";

        public ProyectoFacturacion.FactCliente[] Cliente(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.FactCliente[]>(json);
        }

        public ProyectoFacturacion.FactTipoPago[] TipoPagos(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.FactTipoPago[]>(json);
        }
        public ProyectoFacturacion.productos[] Productos(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.productos[]>(json);
        }

        public ProyectoFacturacion.productos ProductoElegido(string url)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.Headers.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk5NzAwOTAsImV4cCI6MTY5MDA1NjQ5MH0.M-ufLXy44Bk7_M8UKD-5pVm1fZJ-TTH9Ffi517vqBHQ");
            var json = api.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.productos>(json);
        }

        public ProyectoFacturacion.FactCliente ClienteElegido(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoFacturacion.FactCliente>(json);
        }

        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk3OTg2NTcsImV4cCI6MTY4OTg4NTA1N30.NP8xrg50oQbCygS-HJAu1rSSrz4EECKzGT96c31ZQKw");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ik1hdGVpdG8iLCJpYXQiOjE2ODk3MjA3MDYsImV4cCI6MTY4OTgwNzEwNn0.L1yB4dOxJV35HQjdlu4R3_VULz4ybRf0xCpsHFwzq4g");
            return httpClient;
        }

        private List<productos> listaProductos()
        {
            var productos = Productos(UrlPro).Where(p => p.pro_stock > 0);
            var lista = productos.Select(f => new productos
            {
                pro_id = f.pro_id,
                pro_nombre = f.pro_nombre,
                pro_pvp = f.pro_pvp,
                pro_stock = f.pro_stock,
                pro_valor_iva = f.pro_valor_iva
            })
            .ToList();
            return lista;
        }

        private List<FactCliente> listaClientes()
        {
            var clientes = Cliente(UrlCli).Where(p => p.Estado == true);
            var lista = clientes.Select(f => new FactCliente
            {
                Identificacion = f.Identificacion,
                Nombre = f.Nombre        
            })
            .ToList();
            return lista;
        }
        private List<FactTipoPago> ListaTipoPago()
        {
            var tipopago = TipoPagos(UrlTipo);
            var lista = tipopago.Select(f => new FactTipoPago
            {
                IdTipoPago = f.IdTipoPago,
                Tipo = f.Tipo
            })
            .ToList();
            return lista;
        }




        [HttpGet]
        public ActionResult Create()
        {
            var nuevaFacturaCabecera = new ProyectoFacturacion.FactFacturaCabecera();
            // Aquí, puedes inicializar propiedades o realizar otras operaciones si es necesario.

            ViewBag.ListaClientes = listaClientes();
            ViewBag.ListaTipoPago = ListaTipoPago();
            ViewBag.ListaProductos = listaProductos();

            return View(nuevaFacturaCabecera);
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
                var response = httpClient.GetAsync(UrlPro).Result;
                response.EnsureSuccessStatusCode();
                var data = response.Content.ReadAsStringAsync().Result;
                var datos = JsonConvert.DeserializeObject<List<productos>>(data);
                return View(datos);
            }

        }

        // GET: FactFacturaCabeceraController/Details/5
        public ActionResult Details(int id)
        {
            var datos = crud.Select_ById(UrlFact, id.ToString());
            return View(datos);
        }

        // GET: FactFacturaCabeceraController/Create
       
        // POST: FactFacturaCabeceraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacFacturacion datos)
        {
            try
            {
                crud.Insert(UrlFact, datos);
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
            var datos = crud.Select_ById(UrlFact, id.ToString());
            return View(datos);
        }

        // POST: FactFacturaCabeceraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FacFacturacion datos)
        {
            try
            {
                crud.Update(UrlFact, id.ToString(), datos);
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
            var datos = crud.Select_ById(UrlFact, id.ToString());
            return View(datos);
        }

        // POST: FactFacturaCabeceraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FacFacturacion datos)
        {
            try
            {
                crud.Delete(UrlFact, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
