using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Entities.Enumeration;

namespace EntidadBancaria.Entities.Entidades
{
    public class OrdenDePago
    {
        public virtual int Id { get; set; }
        public virtual decimal Monto { get; set; }
        public virtual MonedaEnum Moneda { get; set; }
        public virtual EstadoOrdenPagoEnum Estado { get; set; }
        public virtual DateTime FechaDePago { get; set; }
        public virtual int IdSucursal { get; set; }
        public virtual Sucursal Sucursal { get; set; }

    }
}
