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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cate = _categoryService.GetCategories();
            return View(cate);
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            var cate = _categoryService.Search(key);
            return View(cate);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CateId,CateName,CateDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(category);
                _categoryService.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CateId,CateName,CateDescription")] Category category)
        {
            if (id != category.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.UpdateCategory(category);
                    _categoryService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            _categoryService.Save();
            return RedirectToAction("Index");
        }
    }
}
