using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadBancaria.Entities.Entidades
{
    public class Banco
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual DateTime FechaDeRegistro { get; set; }
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
