using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.BEAN
{
    public class ClienteBEAN
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido  { get; set; }
        public string NumDocumento { get; set; }
        public string Estado { get; set; }

    }
}