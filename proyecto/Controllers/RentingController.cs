﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model;
using proyecto.Areas.Admin.Filters;


namespace proyecto.Controllers
{
    [Autenticado]
    public class RentingController : Controller
    {





        private Orden orden = new Orden();
        private Empresa miempresalista = new Empresa();
        private Sucursal misucursal = new Sucursal();
        private DetalleOrden detalleorden = new DetalleOrden();
        private Hardware inventario = new Hardware();

       

        public JsonResult CargarOrden(AnexGRID grid)
        {
            return Json(orden.Listar(grid));
        }

        public ActionResult Index()
        {
            return View();
        }

        //CRUD DE ORDEN
        public ActionResult generarorden(int id = 0, int id_em = 3)
        {
            //para mostrar empresa
            Cascada empresasucursal = new Cascada();
            var list_empresa = empresasucursal.GetEmpresa();
            ViewBag.miempresa = list_empresa;


            return View(
                id == 0 ? new Orden()
                        : orden.Obtener(id)
            );
        }

        [HttpPost]
        public JsonResult Search_Cliente(string Prefix)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {
                var resultado = (from N in ctx.Cliente.ToList()
                                 where N.nmcliente.ToLower().StartsWith(Prefix.ToLower())
                                 select new { N.nmcliente });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }

        //Para Buscar Cliente
        [HttpPost]
        public JsonResult Search_Empresa(string Prefix_empresa)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {

                var resultado = (from N in ctx.Empresa.ToList()
                                 where N.nmempresa.ToLower().StartsWith(Prefix_empresa.ToLower())
                                 select new { N.nmempresa });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public JsonResult Search_Sucursal(string Prefix_Sucursal)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {

                var resultado = (from N in ctx.Sucursal.ToList()
                                 where N.nmsucursal.ToLower().StartsWith(Prefix_Sucursal.ToLower())
                                 select new { N.nmsucursal });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Guardar(Orden model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.href = Url.Content("~/home/index/");
                }
            }

            return Json(rm);
        }
    }
}