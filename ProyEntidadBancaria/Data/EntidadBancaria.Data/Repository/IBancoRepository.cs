using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Data.Repository
{
    public interface IBancoRepository:IDisposable
    {
        List<Banco> Listar();
        Banco ObtenerById(int id);
        bool Actualizar(Banco banco);
        bool Registrar(Banco banco);
        bool Eliminar(int id);
    }
}
