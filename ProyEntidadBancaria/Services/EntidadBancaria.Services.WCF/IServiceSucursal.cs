using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Services.WCF
{
    [ServiceContract]
    public interface IServiceSucursal
    {
        [OperationContract]
        List<Sucursal> ListarByIdBanco(int idBanco);
    }
}
