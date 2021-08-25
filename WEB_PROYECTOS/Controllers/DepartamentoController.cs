using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartamentoController : Controller
    {
        // GET: Departamento        
        public ActionResult Index()
        {
            var dpatos = DepartamentoCN.ListarDepartamentos();
            return View(dpatos);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de Departamento.");
                    return View(dpto);
                }

                DepartamentoCN.Agregar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al agragar un Departamento");
                return View(dpto);
            }
        }

        public ActionResult GetDepartamento(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
            return View(dpto);
        }

        public JsonResult GetDepartamentos()
        {
            var lista = DepartamentoCN.ListarDepartamentos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Editar(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de Departamento.");
                    return View(dpto);
                }

                DepartamentoCN.Editar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               ModelState.AddModelError("", "Ocurrio un error al Editar un Departamento");
               return View(dpto);

            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var dpto = DepartamentoCN.GetDepartamento(id.Value);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoCN.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al Eliminar un Departamento");
                return View();
                //return View(dpto);
            }
        }    
    }
}