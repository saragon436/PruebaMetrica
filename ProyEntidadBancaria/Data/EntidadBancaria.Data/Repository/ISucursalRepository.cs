using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Data.Repository
{
    public interface ISucursalRepository:IDisposable
    {
        List<Sucursal> ListarTodas();
        List<Sucursal> Listar(int idBanco);
        Sucursal ObtenerById(int id);
        bool Actualizar(Sucursal sucursal);
        bool Registrar(Sucursal sucursal);
        bool Eliminar(int id);
    }
}
