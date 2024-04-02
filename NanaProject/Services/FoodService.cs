using System.Diagnostics;
using NanaProject.Interfaces;
using NanaProject.Models;
using Microsoft.EntityFrameworkCore;
using NanaProject.ViewModels;

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

    public FoodCreateEditViewModel GetByIdCate (int id)
    {
        // return _context.Foods.Where( f => f.FoodId == id).SingleOrDefault();
        var food = _context.Foods.FirstOrDefault(f => f.FoodId == id);

        if (food is null)
        {
            return new FoodCreateEditViewModel();
        }

        return new FoodCreateEditViewModel()
        {
            FoodId = food.FoodId,
            FoodPhoto = food.FoodPhoto,
            FoodName = food.FoodName,
            CateId = food.CateId,
            Quantity = food.Quantity,
            Status = food.Status,
            FoodDescription = food.FoodDescription
        };
    }
}