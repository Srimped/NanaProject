using System.Diagnostics;
using NanaProject.Models;

namespace NanaProject.Interfaces;

public interface IFoodService 
{
    List<Food> GetFoods();
    void Save();
    void CreateFood(Food food);
    void UpdateFood(Food food);
    void DeleteFood(int id);
    Food GetById (int id);
}