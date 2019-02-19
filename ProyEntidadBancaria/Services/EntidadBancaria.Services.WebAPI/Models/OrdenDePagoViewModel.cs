using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadBancaria.Services.WebAPI.Models
{
    public class OrdenDePagoViewModel
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string MonedaDesc { get; set; }
        public string EstadoDesc { get; set; }
        public DateTime FechaDePago { get; set; }
        public string Sucursal { get; set; }
    }
}