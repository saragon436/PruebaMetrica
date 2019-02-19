using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EntidadBancaria.Entities.Entidades;
using EntidadBancaria.Entities.Enumeration;
using EntidadBancaria.Business.Component;
using EntidadBancaria.Services.WebAPI.Models;
using EntidadBancaria.Framework;

namespace EntidadBancaria.Services.WebAPI.Controllers
{
    public class OrdenDePagoController : ApiController
    {

        // GET: api/OrdenDePago/1
        [ResponseType(typeof(OrdenDePagoViewModel))]
        public IHttpActionResult GetOrdenDePagos(int id)
        {
            var ordenComponent = new OrdenDePagoComponent();
            var ordenes = ordenComponent.Listar(id).Select(x => new OrdenDePagoViewModel() 
            {
                Id=x.Id,
                Monto=x.Monto,
                MonedaDesc = x.Moneda.GetDisplayName(),
                EstadoDesc=x.Estado.GetDisplayName(),
                Sucursal=x.Sucursal.Nombre
            });
            return Ok(ordenes);
        }
    }
}