using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EntidadBancaria.Entities.Enumeration;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.UI.MVC.Models
{
    public class OrdenDePagoViewModel
    {
        public int Id { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public MonedaEnum Moneda { get; set; }
        public string MonedaDesc { get; set; }
        [Required]
        public EstadoOrdenPagoEnum Estado { get; set; }
        public string EstadoDesc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDePago { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
    }
}