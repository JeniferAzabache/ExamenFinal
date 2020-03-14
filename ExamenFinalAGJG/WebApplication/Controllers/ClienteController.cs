using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.BEAN;
using WebApplication.Models.Conection;

namespace WebApplication.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            try
            { 
                List<tbCliente> listaClientes;
                using (var db = new BD_ExamenFinalEntities())
                {
                    listaClientes = db.tbCliente.ToList();


                    return View(listaClientes);
                 }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}