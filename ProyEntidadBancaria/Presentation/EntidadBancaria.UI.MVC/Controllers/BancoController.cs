using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntidadBancaria.Business.Component;
using EntidadBancaria.UI.MVC.Models;
using EntidadBancaria.Entities.Entidades;
using AutoMapper;

namespace EntidadBancaria.UI.MVC.Controllers
{
    public class BancoController : Controller
    {
        private BancoComponent bancoComponent = new BancoComponent();

        public ActionResult Listar()
        {
            var bancos = bancoComponent.Listar().Select(x => new BancoViewModel()
                {
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    FechaDeRegistro = x.FechaDeRegistro,
                    Id = x.Id
                });
            return View(bancos);
        }
        public ActionResult Editar(int id=0)
        {
            if(id==0)
                return View(new BancoViewModel());
            else
            {
                var banco = bancoComponent.ObtenerById(id);
                Mapper.CreateMap<Banco, BancoViewModel>();
                var bancoViewModel = Mapper.Map<Banco, BancoViewModel>(banco);
                return View(bancoViewModel);
            }
        }

        public ActionResult Guardar(BancoViewModel bancoViewModel)
        {
            Mapper.CreateMap<BancoViewModel, Banco>();
            var banco = Mapper.Map<BancoViewModel, Banco>(bancoViewModel);

            var result = bancoViewModel.Id > 0 ?
                    bancoComponent.Actualizar(banco) :
                    bancoComponent.Registrar(banco);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al guardar informacion del Banco";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }
        public ActionResult Eliminar(int id)
        {
            var result = bancoComponent.Eliminar(id);

            if (!result)
            {
                ViewBag.Mensaje = "Ocurrio un error al eliminar el banco";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }
    }
}
