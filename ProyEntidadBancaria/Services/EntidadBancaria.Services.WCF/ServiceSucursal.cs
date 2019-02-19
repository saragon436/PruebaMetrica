using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntidadBancaria.Entities.Entidades;
using EntidadBancaria.Business.Component;

namespace EntidadBancaria.Services.WCF
{
    public class ServiceSucursal : IServiceSucursal
    {
        public List<Sucursal> ListarByIdBanco(int idBanco)
        {
            var sucursalComponent = new SucursalComponent();
            var sucursales = sucursalComponent.Listar(idBanco);
            return sucursales;
        }
    }
}
