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

namespace EntidadBancaria.UI.MVC.Controllers
{
    public class SucursalController : Controller
    {
        private SucursalComponent sucursalComponent = new SucursalComponent();
        public ActionResult Listar(int idBanco=0)
        {
            var bancoComponent=new BancoComponent();
            ViewBag.Bancos = new SelectList(bancoComponent.Listar()??Enumerable.Empty<Banco>(),"Id","Nombre");
            var sucursales = sucursalComponent.Listar(idBanco).Select(x => new SucursalViewModel()
            {
                Nombre = x.Nombre,
                Direccion = x.Direccion,
                FechaDeRegistro = x.FechaDeRegistro,
                Id = x.Id,
                IdBanco=x.IdBanco,
                Banco=x.Banco.Nombre
            });
            return View(sucursales);
        }
        public ActionResult Editar(int id = 0)
        {
            var bancoComponent = new BancoComponent();
            ViewBag.Bancos = new SelectList(bancoComponent.Listar() ?? Enumerable.Empty<Banco>(), "Id", "Nombre");
            if (id == 0)
                return View(new SucursalViewModel());
            else
            {
                var sucursal = sucursalComponent.ObtenerById(id);
                Mapper.CreateMap<Sucursal, SucursalViewModel>();
                var sucursalViewModel = Mapper.Map<Sucursal, SucursalViewModel>(sucursal);
                return View(sucursalViewModel);
            }
        }

        public ActionResult Guardar(SucursalViewModel sucursalViewModel)
        {
            Mapper.CreateMap<SucursalViewModel, Sucursal>();
            var banco = Mapper.Map<SucursalViewModel, Sucursal>(sucursalViewModel);

            var result = sucursalViewModel.Id > 0 ?
                    sucursalComponent.Actualizar(banco) :
                    sucursalComponent.Registrar(banco);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al guardar informacion de sucursal";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }
        public ActionResult Eliminar(int id)
        {
            var result = sucursalComponent.Eliminar(id);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al eliminar sucursal";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }

    }
}
