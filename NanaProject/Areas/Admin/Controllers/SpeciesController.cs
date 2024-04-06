using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NanaProject.Interfaces;
using NanaProject.Models;

namespace NanaProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SpeciesController : Controller
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var spec = _speciesService.GetSpecies();
            return View(spec);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = _speciesService.GetById(id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SpecId,SpecName,SpecDescription")] Species species)
        {
            if (ModelState.IsValid)
            {
                _speciesService.CreateSpecies(species);
                _speciesService.Save();
                return RedirectToAction("Index");
            }
            return View(species);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = _speciesService.GetById(id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SpecId,SpecName,SpecDescription")] Species species)
        {
            if (id != species.SpecId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _speciesService.UpdateSpecies(species);
                    _speciesService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(species);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = _speciesService.GetById(id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _speciesService.DeleteSpecies(id);
            _speciesService.Save();
            return RedirectToAction("Index");
        }
    }
}
