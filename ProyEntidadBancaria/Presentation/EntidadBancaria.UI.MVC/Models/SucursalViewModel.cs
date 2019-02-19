using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntidadBancaria.UI.MVC.Models
{
    public class SucursalViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeRegistro { get; set; }
        [Required]
        public int IdBanco { get; set; }
        public string Banco { get; set; }
    }
}