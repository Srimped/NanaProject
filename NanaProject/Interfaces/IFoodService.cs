using System.Diagnostics;
using NanaProject.Models;
using NanaProject.ViewModels;

namespace NanaProject.Interfaces;

public interface IFoodService 
{
    List<Food> GetFoods();
    void Save();
    void CreateFood(Food food);
    void UpdateFood(Food food);
    void DeleteFood(int id);
    Food GetById (int id);
    List<Food> Search (string key);
    public FoodCreateEditViewModel GetByIdCate (int id); 
}