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
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;

        public FoodController(IFoodService foodService, ICategoryService categoryService)
        {
            _foodService = foodService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var food = _foodService.GetFoods();
            return View(food);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = _foodService.GetById(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var model = new FoodCreateEditViewModel
            {
                Categories = GetCate()
            };
            return View(model);
        }

        // POST: Food/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FoodId,FoodPhoto,FoodName,CateId,Quantity,Status,FoodDescription")] Food food)
        {
            if (ModelState.IsValid)
            {   
                _foodService.CreateFood(food);
                _foodService.Save();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var food = _foodService.GetByIdCate(id);
            food.Categories = GetCate();
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FoodId,FoodPhoto,FoodName,CateId,Quantity,Status,FoodDescription")] Food food)
        {
            if (id != food.FoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _foodService.UpdateFood(food);
                    _foodService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _foodService.DeleteFood(id);
            _foodService.Save();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetCate()
        {
            var cates = new List<SelectListItem>()
        {
            new SelectListItem(){
                Value = "",
                Text= "---Select Supply Category---"
            }
        };
            cates.AddRange(_categoryService.GetCategories().Select(c => new SelectListItem()
            {
                Value = c.CateId.ToString(),
                Text = c.CateName
            }).ToList());

            return cates;
        }
    }
}
