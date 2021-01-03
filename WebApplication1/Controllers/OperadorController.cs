using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OperadorController : Controller
    {

        /*
        private readonly IOperador ope;
        public OperadorController(IOperador operador)
        {
            ope = operador;
        }
        */
        public ActionResult Index()
        {
            OperadorDAL dal = new OperadorDAL();
            var lst = dal.GetAllOperadors();

            return View(lst);
        }

       
        // GET: Operador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operador/Create
        [HttpPost]
        public ActionResult Create(Operador pOperador)
        {
            try
            {
                OperadorDAL dal = new OperadorDAL();
                pOperador.Id = (new Random()).Next(2000);
                dal.AddOperador(pOperador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operador/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OperadorDAL dal = new OperadorDAL();

            Operador vAuxOperador = dal.GetOperador(id);

            if (vAuxOperador == null) return HttpNotFound();

            OperadorViewModel vOperadorViewModel = new OperadorViewModel
            {
                Id = vAuxOperador.Id,
                Name = vAuxOperador.Nome
            };


            var vPerfisOperador = dal.GetRolesOperador(id);
            var vTodasRoles = dal.GetRoles();

            vOperadorViewModel.RolesIds = vPerfisOperador.Select(c => c.Id.ToString()).ToList();

            MultiSelectList teamsList = null;

            if (vPerfisOperador != null)
            {
               teamsList = new MultiSelectList(vTodasRoles.ToList().OrderBy(i => i.Nome), "Id", "Nome", vPerfisOperador.Select(c => c.Id.ToString()).ToList());
            }
            else
            {
                 teamsList = new MultiSelectList(vTodasRoles.ToList().OrderBy(i => i.Nome), "Id", "Nome");
            }

            vOperadorViewModel.Roles = teamsList;
            return View(vOperadorViewModel);
        }

        // POST: Operador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Operador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Operador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
