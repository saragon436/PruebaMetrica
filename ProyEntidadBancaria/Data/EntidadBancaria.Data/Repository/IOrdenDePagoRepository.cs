using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Data.Repository
{
    public interface IOrdenDePagoRepository:IDisposable
    {
        List<OrdenDePago> Listar(int idSucursal);
        OrdenDePago ObtenerById(int id);
        bool Actualizar(OrdenDePago ordenDePago);
        bool Registrar(OrdenDePago ordenDePago);
        bool Eliminar(int id);
    }
}
