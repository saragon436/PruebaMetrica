using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadBancaria.Entities.Entidades
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public int IdBanco { get; set; }
        public virtual Banco Banco { get; set; }
        public virtual ICollection<OrdenDePago> OrdenDePago
        {
            get;
            set;
        }
    }
}
