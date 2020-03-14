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
                //string sql =
                //   @"select cc.idContactabilidad, col.nombreColaborador, cli.nombreCliente, pro.nombreProducto,fechaContactoCliente
                //        from tb_ContactoCliente cc inner join tb_Colaborador col
                //        on cc.idColaborador =col.idColaborador inner join tb_Cliente cli
                //        on cc.idCliente = cli.idCliente inner join tb_Producto pro
                //        on cc.idProducto = pro.idProducto";


                List<tbCliente> listaClientes;
                using (var db = new BD_ExamenFinalEntities())
                {
                    var lista = Select IdCliente, Nombre, NumDocumento from tbCliente where Estado = 'A';
                               
                                select new ClienteBEAN
                                {
                                   
                                };

                    //List < tb_ContactoCliente > listContac = db.tb_ContactoCliente.ToList();
                    List<ClienteBEAN> listContac = lista.ToList();
                    return View(listContac);

                    //return View(db.Database.SqlQuery<ClienteBEAN>(sql).ToList());
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