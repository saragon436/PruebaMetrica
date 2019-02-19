using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntidadBancaria.UI.MVC.Models
{
    public class BancoViewModel
    {
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string Direccion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime FechaDeRegistro { get; set; }
    }
}