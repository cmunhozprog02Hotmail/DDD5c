﻿using Modelo.Cadastros;
using Servicos.Cadastros;
using System.Net;
using System.Web.Mvc;

namespace DDD5c.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }

        // GET: Create

        public ActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {

            return GravarFabricante(fabricante);
        }

        // GET: Testes/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
                try
                {
                    Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                    TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper()
                    + " foi removido";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
    }
}