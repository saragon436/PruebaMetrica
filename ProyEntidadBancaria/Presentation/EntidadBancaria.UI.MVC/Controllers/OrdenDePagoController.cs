using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntidadBancaria.Business.Component;
using EntidadBancaria.UI.MVC.Models;
using EntidadBancaria.Entities.Entidades;
using AutoMapper;
using EntidadBancaria.Entities.Enumeration;
using EntidadBancaria.Framework;

namespace EntidadBancaria.UI.MVC.Controllers
{
    public class OrdenDePagoController : Controller
    {
        private OrdenDePagoComponent ordenComponent = new OrdenDePagoComponent();

        public ActionResult Listar(int idSucursal=0)
        {
            var sucursalComponent = new SucursalComponent();
            ViewBag.Sucursales = new SelectList(sucursalComponent.ListarTodas() ?? Enumerable.Empty<Sucursal>(), "Id", "Nombre");
            var ordenes = ordenComponent.Listar(idSucursal).Select(x => new OrdenDePagoViewModel()
            {
                Id=x.Id,
                EstadoDesc=x.Estado.GetDisplayName(),
                FechaDePago=x.FechaDePago,
                IdSucursal=x.IdSucursal,
                MonedaDesc=x.Moneda.GetDisplayName(),
                Monto=x.Monto,
                Sucursal=x.Sucursal.Nombre
            });
            return View(ordenes);
        }
        public ActionResult Editar(int id = 0)
        {
            ViewBag.Monedas = MonedaEnum.Dolares.ToSelectList("",true);
            ViewBag.Estados = EstadoOrdenPagoEnum.Anulada.ToSelectList("",true);
            var sucursalComponent = new SucursalComponent();
            ViewBag.Sucursales = new SelectList(sucursalComponent.ListarTodas() ?? Enumerable.Empty<Sucursal>(), "Id", "Nombre");
            if (id == 0)
                return View(new OrdenDePagoViewModel());
            else
            {
                var orden = ordenComponent.ObtenerById(id);
                Mapper.CreateMap<OrdenDePago, OrdenDePagoViewModel>();
                var ordenDePagoViewModel = Mapper.Map<OrdenDePago, OrdenDePagoViewModel>(orden);
                return View(ordenDePagoViewModel);
            }
        }

        public ActionResult Guardar(OrdenDePagoViewModel ordenPagoViewModel)
        {
            Mapper.CreateMap<OrdenDePagoViewModel, OrdenDePago>();
            var ordenDePago = Mapper.Map<OrdenDePagoViewModel, OrdenDePago>(ordenPagoViewModel);

            var result = ordenPagoViewModel.Id > 0 ?
                    ordenComponent.Actualizar(ordenDePago) :
                    ordenComponent.Registrar(ordenDePago);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al guardar informacion de orden de pago";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }
        public ActionResult Eliminar(int id)
        {
            var result = ordenComponent.Eliminar(id);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al eliminar orden de pago";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }

    }
}
