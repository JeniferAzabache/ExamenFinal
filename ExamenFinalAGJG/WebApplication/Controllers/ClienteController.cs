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
        public ActionResult ListaClientes()
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
            //return View(listaClientes);
        }
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(tbCliente clien)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new BD_ExamenFinalEntities())
                {
                    clien.Estado = "A";
                    db.tbCliente.Add(clien);
                    db.SaveChanges();
                    return RedirectToAction("ListaClientes");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                //throw;
                return View();
            }

        }



    }
}