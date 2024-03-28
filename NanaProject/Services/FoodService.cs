using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NanaProject.Services;

public class FoodService : IFoodService
{
    private readonly NanaDbContext _context;

    public FoodService(NanaDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public List<Food> GetFoods()
    {
        return _context.Foods.ToList();
    }

    public void CreateFood (Food food)
    {
        _context.Add(food);
    }

    public void UpdateFood (Food food)
    {
        _context.Foods.Update(food);
    }

    public void DeleteFood (int id)
    {
        Food food = GetById(id);
        _context.Foods.Remove(food);
    }

    public Food GetById (int id)
    {
        return _context.Foods.Where( f => f.FoodId == id).SingleOrDefault();
    }
}