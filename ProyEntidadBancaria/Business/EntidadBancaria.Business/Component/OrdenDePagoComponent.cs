using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Data.ImplementsRepository;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Business.Component
{
    public class OrdenDePagoComponent
    {
        private OrdenDePagoRepository ordenDePagoRepository = new OrdenDePagoRepository();
        public List<OrdenDePago> Listar(int idSucursal)
        {
            return ordenDePagoRepository.Listar(idSucursal);
        }
        public OrdenDePago ObtenerById(int id)
        {
            return ordenDePagoRepository.ObtenerById(id);
        }

        public bool Actualizar(OrdenDePago ordenDePago)
        {
            return ordenDePagoRepository.Actualizar(ordenDePago);
        }

        public bool Registrar(OrdenDePago ordenDePago)
        {
            return ordenDePagoRepository.Registrar(ordenDePago);
        }

        public bool Eliminar(int id)
        {
            return ordenDePagoRepository.Eliminar(id);
        }
    }
}
