using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyEmpresa.Entidad;
using ProyEmpresa.Logic;
using ProyEmpresa.Logic.Logica;

namespace ProyEmpresa.Web.Controllers
{
    public class UsuarioController : Controller
    {

        Log_Usuario log_Usuario = new Log_Usuario();


        // GET: Usuario
        public ActionResult Index()
        {

            ViewBag.ListaUsuarios = log_Usuario.ListaUsuario();
            return View();
        }   

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Registro(Ent_Usuario ent_Usuario)
        {
            try
            {
                log_Usuario.Registra(ent_Usuario);
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
