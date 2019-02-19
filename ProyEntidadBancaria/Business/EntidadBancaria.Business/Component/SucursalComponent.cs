using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Data.ImplementsRepository;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Business.Component
{
    public class SucursalComponent
    {
        private SucursalRepository sucursalRepository = new SucursalRepository();
        public List<Sucursal> ListarTodas()
        {
            return sucursalRepository.ListarTodas();
        }
        public List<Sucursal> Listar(int idBanco)
        {
            return sucursalRepository.Listar(idBanco);
        }
        public Sucursal ObtenerById(int id)
        {
            return sucursalRepository.ObtenerById(id);
        }

        public bool Actualizar(Sucursal sucursal)
        {
            return sucursalRepository.Actualizar(sucursal);
        }

        public bool Registrar(Sucursal sucursal)
        {
            return sucursalRepository.Registrar(sucursal);
        }

        public bool Eliminar(int id)
        {
            return sucursalRepository.Eliminar(id);
        }
    }
}
