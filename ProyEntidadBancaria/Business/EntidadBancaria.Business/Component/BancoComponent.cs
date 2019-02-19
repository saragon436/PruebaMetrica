using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Data.ImplementsRepository;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Business.Component
{
    public class BancoComponent
    {
        private BancoRepository bancoRepository = new BancoRepository();
        public List<Banco> Listar()
        {
            return bancoRepository.Listar();
        }
        public Banco ObtenerById(int id)
        {
            return bancoRepository.ObtenerById(id);
        }

        public bool Actualizar(Banco banco)
        {
            return bancoRepository.Actualizar(banco);
        }

        public bool Registrar(Banco banco)
        {
            return bancoRepository.Registrar(banco);
        }

        public bool Eliminar(int id)
        {
            return bancoRepository.Eliminar(id);
        }
    }
}
