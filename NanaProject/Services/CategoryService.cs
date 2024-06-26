using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NanaProject.Services;

public class CategoryService : ICategoryService
{
    private readonly NanaDbContext _context;

    public CategoryService(NanaDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public List<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public void CreateCategory (Category category)
    {
        _context.Add(category);
    }

    public void UpdateCategory (Category category)
    {
        _context.Categories.Update(category);
    }

    public void DeleteCategory (int id)
    {
        Category cate = GetById(id);
        _context.Categories.Remove(cate);
    }

    public List<Category> Search(string key)
    {
        return _context.Categories.Where(c => c.CateName.Contains(key)).ToList();
    }

    public Category GetById (int id)
    {
        return _context.Categories.Where( c => c.CateId == id).SingleOrDefault();
    }
}