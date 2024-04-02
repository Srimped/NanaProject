using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NanaProject.Interfaces;
using NanaProject.Models;
using NanaProject.ViewModels;

namespace NanaProject.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly ISpeciesService _speciesService;

        public PetController(IPetService petService, ISpeciesService speciesService)
        {
            _petService = petService;
            _speciesService = speciesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pet = _petService.GetPets();
            return View(pet);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = _petService.GetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PetCreateEditViewModel
            {
                Specieses = GetSpec()
            };
            return View(model);
        }

        // POST: Pet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Photo,Name,TypeId,Old,CheckIn,CheckOut,Description")] Pet pet)
        {
            if (ModelState.IsValid)
            {

                _petService.CreatePet(pet);
                _petService.Save();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // GetSpec();
            var pet = _petService.GetByIdSpec(id);
            pet.Specieses = GetSpec();
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Photo,Name,TypeId,Old,CheckIn,CheckOut,Description")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _petService.UpdatePet(pet);
                    _petService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // [HttpGet]
        // public IActionResult Delete(int id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var pet = _petService.GetById(id);
        //     if (pet == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(pet);
        // }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _petService.DeletePet(id);
            _petService.Save();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetSpec()
        {
            var specs = new List<SelectListItem>()
        {
            new SelectListItem(){
                Value = "",
                Text= "---Select Pet Species---"
            }
        };
            specs.AddRange(_speciesService.GetSpecies().Select(s => new SelectListItem()
            {
                Value = s.SpecId.ToString(),
                Text = s.SpecName
            }).ToList());

            return specs;
        }
    }
}
